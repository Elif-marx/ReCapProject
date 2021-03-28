using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
            public List<RentDetailDto> GetRentalDetailDtos()
            {
                using (ReCapProjectContext context = new ReCapProjectContext())
                {
                    var result = from r in context.Rentals
                                 join c in context.Cars
                                 on r.CarId equals c.CarId
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join cs in context.Customers
                                 on r.CustomerId equals cs.CustomerId
                                 join u in context.Users
                                 on cs.UserId equals u.Id
                                 select new RentDetailDto
                                 {
                                     Id = r.RentalId,
                                     CarId = c.CarId,
                                     CarDescription = c.Description,
                                     CompanyName = cs.CompanyName,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate
                                 };
                    return result.ToList();

                }
            }
        }
    }

