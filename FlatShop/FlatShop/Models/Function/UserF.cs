using FlatShop.Models.EF;
using FlatShop.Models.EF.MoreEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class UserF
    {
        private MyDbContext context;

        public UserF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        //trả về 1 đối tượng sản phẩm

        public User FindEntity(long ID)
        {
            User dbEntry = context.Users.Find(ID);
            return dbEntry;

        }

        public bool Insert(User model)
        {
            User dbEntry = context.Users.Find(model.Email);
            if (dbEntry != null) return false;
            context.Users.Add(model);
            context.SaveChanges();
            return true;
        }


        public bool Update(User model)
        {
            User dbEntry = context.Users.Find(model.Email);
            if (dbEntry == null) return false;
            dbEntry.Email = model.Email;
            dbEntry.Password = model.Password;
            dbEntry.Address = model.Address;
            dbEntry.Phone = model.Phone;
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(User model)
        {
            User dbEntry = context.Users.Find(model.Email);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.Users.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }

        public bool CheckEmail(string Email)
        {
            return context.Users.Count(x => x.Email == Email) > 0;
        }
        public Account Login(string Email, string Password)
        {
            var result = context.Users.Where(a => a.Email.Equals(Email) && a.Password.Equals(Password)).FirstOrDefault();

            Account acc = null;
            if (result != null)
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