﻿public class Province
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }


    public Province(string name, double latitude, double longitude)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;

    }
}