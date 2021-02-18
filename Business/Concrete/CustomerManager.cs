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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _customDal.Add(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Customer> GetbyId(int Id)
        {
            return new SuccessDataResult<Customer>(_customDal.Get(p => p.CustomerId == Id), Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            _customDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
