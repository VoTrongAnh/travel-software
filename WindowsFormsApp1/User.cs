using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class User
    {
        private string maUser;
        private string tenTaiKhoanUser;
        private string maDuKhach;
        public User(string maUser, string tenTaiKhoanUser, string maDuKhach)
        {
            this.maUser = maUser;
            this.tenTaiKhoanUser = tenTaiKhoanUser;
            this.maDuKhach = maDuKhach;
        }

        public string GetMaUser()
        {
            return this.maUser;
        }

        public string GetTenTaiKhoanUser()
        {
            return this.tenTaiKhoanUser;
        }
        public string GetMaDuKhach()
        {
            return this.maDuKhach;
        }
    }

}
