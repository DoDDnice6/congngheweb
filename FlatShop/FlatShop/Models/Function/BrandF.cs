using FlatShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class BrandF
    {
        private MyDbContext context;

        public BrandF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<Brand> Brands
        {
            get { return context.Brands; }
        }

        //trả về 1 đối tượng sản phẩm

        public Brand FindEntity(long ID)
        {
            Brand dbEntry = context.Brands.Find(ID);
            return dbEntry;

        }

        public bool Insert(Brand model)
        {
            Brand dbEntry = context.Brands.Find(model.ID);
            if (dbEntry != null) return false;
            context.Brands.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Update(Brand model)
        {
            Brand dbEntry = context.Brands.Find(model.ID);
            if (dbEntry == null) return false;
            dbEntry.ID = model.ID;
            dbEntry.Name = model.Name;
            dbEntry.Image = model.Image;
           
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(Brand model)
        {
            Brand dbEntry = context.Brands.Find(model.ID);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.Brands.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}