using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapDbContext db = new ReCapDbContext())
            {
                var result = from a in db.Users
                             join b in db.Customers on a.Id equals b.UserId
                             select new CustomerDetailDto { CustomerId = b.CustomerId, UserName = a.FirstName, CompanyName = b.CompanyName };
                return result.ToList();
            }
        }
    }
}
