using FlatShop.Models.EF;
using FlatShop.Models.EF.MoreEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class CustomerF
    {
        private MyDbContext context;

        public CustomerF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<Customer> Customers
        {
            get { return context.Customers; }
        }

        //trả về 1 đối tượng sản phẩm

        public Customer FindEntity(long ID)
        {
            Customer dbEntry = context.Customers.Find(ID);
            return dbEntry;

        }

        public bool Insert(Customer model)
        {
            Customer dbEntry = context.Customers.Find(model.Email);
            if (dbEntry != null) return false;
            context.Customers.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool CheckEmail(string Email)
        {
            return context.Customers.Count(x => x.Email == Email) > 0;
        }


        public Account Login(string Email,string Password)
        {
            var result = context.Customers.Where(a => a.Email.Equals(Email) && a.Password.Equals(Password)).FirstOrDefault();

            Account acc = null;
            if(result!=null)
            {
                acc = new Account();
                acc.Email = result.Email;
                acc.Password = result.Password;
                acc.Roles = (from a in context.Roles
                             join b in context.UserInRoles
                             on a.ID equals b.RoleID
                             where (a.RoleName != null && b.Email.Equals(Email))
                             select a.RoleName).ToList();
            }
            return acc;
        }
    }
}