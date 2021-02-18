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
    public class ColorManager : IColorService
    {
        IColorDal _color;
        public ColorManager(IColorDal color)
        {
            _color = color;
        }
        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult(Messages.Added);
        }
        
        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }
       
        public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll(), Messages.Listed);
        }

        public IDataResult<Color> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<Color>(_color.Get(p => p.ColorId == ColorId));
        }

       
    }
}
