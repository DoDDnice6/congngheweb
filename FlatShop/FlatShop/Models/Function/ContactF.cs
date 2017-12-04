using FlatShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class ContactF
    {
        private MyDbContext context;

        public ContactF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<Contact> Contacts
        {
            get { return context.Contacts; }
        }

        //trả về 1 đối tượng sản phẩm

        public Contact FindEntity(long ID)
        {
            Contact dbEntry = context.Contacts.Find(ID);
            return dbEntry;

        }

        public bool Insert(Contact model)
        {
            Contact dbEntry = context.Contacts.Find(model.ID);
            if (dbEntry != null) return false;
            context.Contacts.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Update(Contact model)
        {
            Contact dbEntry = context.Contacts.Find(model.ID);
            if (dbEntry == null) return false;
            dbEntry.ID = model.ID;
            dbEntry.Name = model.Name;
            dbEntry.Email = model.Email;
            dbEntry.Content = model.Content;
            dbEntry.CreateDate = model.CreateDate;
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(Contact model)
        {
            Contact dbEntry = context.Contacts.Find(model.ID);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.Contacts.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}