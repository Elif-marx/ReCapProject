using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _CarDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.Invalid);
            }
        }
        
        public IResult Delete(Car car)
        {
            _CarDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.BrandId == id),Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
