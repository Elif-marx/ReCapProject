using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarTest();
            //ListCars();
            //BrandTest();
            //foreach (var car in carManager.GetCarDetails().Data)
            //{
            //  Console.WriteLine(car.CarName+" marka  "+car.BrandName);
            //}

            void CarTest()
            {
                CarManager carmanager = new CarManager(new EfCarDal());
                var result = carManager.GetCarDetails();
                if (result.Success==true)
                {
                    foreach (var car in result.Data)
                    {
                        Console.WriteLine(car.Id + "-" + car.CarName + "-" + car.BrandName);
                    }
                }
                else
                {
                    Console.WriteLine(result.Message);
                }

            }
            
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ListCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description + "---Marka:" + car.BrandName + "---Renk:" + car.ColorName + "---Günlük Fiyat:" + car.DailyPrice);
            }
        }
    }
}
