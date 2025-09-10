using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl_GoiY : UserControl
    {
        // Danh sách lưu các câu hỏi và câu trả lời từ database
        private List<(string CauHoi, string CauTraLoi)> dataFromDatabase = new List<(string, string)>();

        public UserControl_GoiY()
        {
            InitializeComponent();
            LoadDataFromDatabase();
            // Gán sự kiện KeyDown
            guna2TextBox1.KeyDown += Guna2TextBox1_KeyDown;
        }
        private void Guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Ngăn tiếng 'bíp' khi nhấn Enter
                e.SuppressKeyPress = true;

                // Gọi sự kiện Click của nút gửi
                guna2Button2_Click(sender, e);
            }
        }
        // Hàm tải dữ liệu từ bảng ChatBot
        private void LoadDataFromDatabase()
        {
            string connectionString = "Server=LAPTOP-97E246FS;Database=QuanLyDuLich;Trusted_Connection=True;";
            string query = "SELECT CauHoi, CauTraLoi FROM ChatBot";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string question = reader["CauHoi"].ToString();
                            string answer = reader["CauTraLoi"].ToString();
                            dataFromDatabase.Add((question, answer));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối tới cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string userInput = guna2TextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(userInput))
            {
                // Hiển thị câu hỏi của người dùng
                guna2TextBox2.AppendText("Bạn: " + userInput + Environment.NewLine);

                // Xử lý câu trả lời từ chatbot
                string botResponse = GetBotResponse(userInput);

                // Hiển thị câu trả lời
                guna2TextBox2.AppendText("Chatbot: " + botResponse + Environment.NewLine);
            }

            // Dọn dẹp TextBox sau khi gửi câu hỏi
            guna2TextBox1.Clear();
        }

        // Hàm xử lý trả lời câu hỏi với TF-IDF
        private string GetBotResponse(string userInput)
        {
            // Chuẩn hóa câu hỏi người dùng
            string processedInput = NormalizeText(userInput);

            // Duyệt qua các câu hỏi trong database
            foreach (var data in dataFromDatabase)
            {
                string processedQuestion = NormalizeText(data.CauHoi);

                // So sánh khớp chính xác
                if (processedInput == processedQuestion)
                {
                    return data.CauTraLoi; // Trả về ngay nếu khớp chính xác
                }
            }

            // Nếu không có khớp chính xác, sử dụng TF-IDF để so sánh
            return GetResponseUsingTFIDF(processedInput);
        }
        // Sử dụng TF-IDF khi không tìm thấy khớp chính xác
        private string GetResponseUsingTFIDF(string processedInput)
        {
            // Chuẩn bị dữ liệu TF-IDF từ database và câu hỏi người dùng
            var corpus = dataFromDatabase.Select(d => NormalizeText(d.CauHoi)).ToList();
            corpus.Add(processedInput); // Thêm câu hỏi của người dùng vào cuối danh sách để tính TF-IDF

            // Tính toán vector TF-IDF
            var tfidfVectors = CalculateTFIDF(corpus);

            // So sánh câu hỏi người dùng với các câu hỏi trong database
            double highestSimilarity = 0;
            int bestMatchIndex = -1;

            for (int i = 0; i < corpus.Count - 1; i++) // Không so sánh với chính câu người dùng
            {
                double similarity = CalculateCosineSimilarity(tfidfVectors.Last(), tfidfVectors[i]);
                if (similarity > highestSimilarity)
                {
                    highestSimilarity = similarity;
                    bestMatchIndex = i;
                }
            }

            // Nếu tìm thấy câu hỏi tương tự với độ tương đồng >= 70%
            if (highestSimilarity >= 0.2)
            {
                return dataFromDatabase[bestMatchIndex].CauTraLoi;
            }
            else
            {
                return "Xin lỗi, tôi không tìm thấy câu trả lời phù hợp.";
            }
        }

        // Tính TF-IDF cho từng câu trong corpus
        private List<Dictionary<string, double>> CalculateTFIDF(List<string> corpus)
        {
            var termFrequencies = corpus.Select(sentence =>
            {
                var words = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return words.GroupBy(w => w)
                            .ToDictionary(g => g.Key, g => g.Count() / (double)words.Length);
            }).ToList();

            var idf = new Dictionary<string, double>();
            var allWords = termFrequencies.SelectMany(tf => tf.Keys).Distinct();

            foreach (var word in allWords)
            {
                int docCount = termFrequencies.Count(tf => tf.ContainsKey(word));
                idf[word] = Math.Log(corpus.Count / (double)(1 + docCount)); // IDF tránh chia 0
            }

            return termFrequencies.Select(tf =>
                tf.ToDictionary(kv => kv.Key, kv => kv.Value * idf[kv.Key])
            ).ToList();
        }

        // Tính cosine similarity giữa 2 vector TF-IDF
        private double CalculateCosineSimilarity(Dictionary<string, double> vector1, Dictionary<string, double> vector2)
        {
            var allKeys = vector1.Keys.Union(vector2.Keys);
            double dotProduct = allKeys.Sum(key =>
            {
                double value1 = vector1.ContainsKey(key) ? vector1[key] : 0;
                double value2 = vector2.ContainsKey(key) ? vector2[key] : 0;
                return value1 * value2;
            });

            double magnitude1 = Math.Sqrt(vector1.Values.Sum(val => val * val));
            double magnitude2 = Math.Sqrt(vector2.Values.Sum(val => val * val));

            return magnitude1 > 0 && magnitude2 > 0 ? dotProduct / (magnitude1 * magnitude2) : 0;
        }

        // Hàm loại bỏ dấu tiếng Việt
        // Hàm chuẩn hóa văn bản: Loại bỏ dấu tiếng Việt, dấu câu, khoảng trắng thừa và chuyển về chữ thường
        private string NormalizeText(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            // Loại bỏ dấu tiếng Việt
            string processed = RemoveVietnameseDiacritics(input);

            // Loại bỏ dấu câu
            char[] punctuation = new char[] { '.', ',', '!', '?', ';', ':', '-', '(', ')', '[', ']', '{', '}', '"', '\'' };
            processed = new string(processed.Where(c => !punctuation.Contains(c)).ToArray());

            // Loại bỏ khoảng trắng thừa và chuyển về chữ thường
            return processed.Trim().ToLower();
        }

        // Hàm loại bỏ dấu tiếng Việt
        private string RemoveVietnameseDiacritics(string input)
        {
            string[] arr1 = new string[]
            {
        "aáàảãạăắằẳẵặâấầẩẫậ",
        "eéèẻẽẹêếềểễệ",
        "iíìỉĩị",
        "oóòỏõọôốồổỗộơớờởỡợ",
        "uúùủũụưứừửữự",
        "yýỳỷỹỵ",
        "dđ",
        "AÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬ",
        "EÉÈẺẼẸÊẾỀỂỄỆ",
        "IÍÌỈĨỊ",
        "OÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢ",
        "UÚÙỦŨỤƯỨỪỬỮỰ",
        "YÝỲỶỸỴ",
        "DĐ"
            };

            string[] arr2 = new string[]
            {
        "a",
        "e",
        "i",
        "o",
        "u",
        "y",
        "d",
        "A",
        "E",
        "I",
        "O",
        "U",
        "Y",
        "D"
            };

            StringBuilder result = new StringBuilder(input);

            // Lặp qua các mảng arr1 và thay thế ký tự có dấu bằng ký tự không dấu
            for (int i = 0; i < arr1.Length; i++)
            {
                foreach (char c in arr1[i])
                {
                    result.Replace(c.ToString(), arr2[i]);
                }
            }

            // Loại bỏ các ký tự không mong muốn khác (nếu có)
            string normalizedString = result.ToString();
            normalizedString = normalizedString.Normalize(NormalizationForm.FormD);
            char[] chars = normalizedString
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new string(chars).Normalize(NormalizationForm.FormC);
        }

    }
}
