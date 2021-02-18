using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;
        public BrandManager(IBrandDal brand)//ctor
        {
            _brand = brand;
        }
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length>2)
            {
                _brand.Add(brand);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.Invalid); 
            }
        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }
        
        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(),Messages.Listed);
        }
        public IDataResult<Brand> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<Brand>(_brand.Get(b => b.BrandId == brandId));
        }
        
    }
}
