using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, ModelYear=2019, DailyPrice=650, Description="BMW M2 COMPETITION"},
                new Car{CarId=2, ModelYear=2016, DailyPrice=500, Description="AUDI A3 SEDAN"},
                new Car{CarId=3,  ModelYear=2017, DailyPrice=1000, Description="ALFA ROMEO GİULİETTA"},
                new Car{CarId=4, ModelYear=2016, DailyPrice=750, Description="BMW M4 SPECIFICATIONS"},
                new Car{CarId=5, ModelYear=2020, DailyPrice=900, Description="AUDI S4"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(cto => cto.CarId == car.CarId);
            _cars.Remove(CarToDelete);  //referans tipi sadece bu kodla silinemez bool string int silinebilir
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)//güncellediği ürünü gönderiyor veritabanına
        {       //veri kaynağındaki referansı(carToUpdate) bulup kendiminkiyle güncelliyorum(car)
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);//foreach gibi çalışır
            carToUpdate.CarId = car.CarId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorName = car.ColorName;
            carToUpdate.BrandName = car.BrandName;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
