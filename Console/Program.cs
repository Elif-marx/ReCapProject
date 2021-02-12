using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ListCars();
            
            
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
              Console.WriteLine(car.CarName+" marka  "+car.BrandName);
            }
            
        }

        private static void ListCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())//getall()
            {
                Console.WriteLine(car.Description + "---Marka:" + car.BrandName + "---Renk:" + car.ColorName + "---Günlük Fiyat:" + car.DailyPrice);
            }
        }
    }
}//Product productToDelete=null;//=new product; dersek gereksiz yere belleği yorarız referans atanır LINQ
