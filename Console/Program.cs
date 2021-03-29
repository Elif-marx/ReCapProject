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
            ListCars();
            //RentalTest();
            //GetAllCarImage();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental = new Rental {CustomerId=1,CarId=914, RentDate = DateTime.Now };
            rentalManager.Add(rental);
            
            Console.WriteLine(rental.RentalId);
            Console.WriteLine(rental.RentDate);
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
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
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
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
        private static void GetAllCarImage()
        {
            CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());
            foreach (var carImage in carImageManager.GetAll().Data)
            {
                Console.WriteLine(carImage.Id + "/" + carImage.CarId + "/" + carImage.ImagePath);
            }
        }
    }
}
