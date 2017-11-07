using FlatShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class CountryF
    {
        private MyDbContext context;

        public CountryF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<Country> Countrys
        {
            get { return context.Countries; }
        }

        //trả về 1 đối tượng sản phẩm

        public Country FindEntity(long ID)
        {
            Country dbEntry = context.Countries.Find(ID);
            return dbEntry;

        }

        public bool Insert(Country model)
        {
            Country dbEntry = context.Countries.Find(model.ID);
            if (dbEntry != null) return false;
            context.Countries.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Update(Country model)
        {
            Country dbEntry = context.Countries.Find(model.ID);
            if (dbEntry == null) return false;
            dbEntry.ID = model.ID;
            dbEntry.Name = model.Name;
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(Country model)
        {
            Country dbEntry = context.Countries.Find(model.ID);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.Countries.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}