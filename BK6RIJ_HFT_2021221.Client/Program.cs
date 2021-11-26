using System;
using BK6RIJ_HFT_2021221.Models;

namespace BK6RIJ_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestServices restService = new RestServices("http://localhost:51716");

            //restService.Post<Brand>(new Brand()
            //{
            //    Name = "Peugeot"
            //}, "brand");

            //var brands = restService.Get<Brand>("brand");
            //var cars = restService.Get<Car>("car");
        }
    }
}
