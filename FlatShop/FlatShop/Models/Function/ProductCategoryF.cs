using FlatShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class ProductCategoryF
    {
        private MyDbContext context;

        public ProductCategoryF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<ProductCategory> ProductCategories
        {
            get { return context.ProductCategories; }
        }

        //trả về 1 đối tượng sản phẩm

        public ProductCategory FindEntity(long ID)
        {
            ProductCategory dbEntry = context.ProductCategories.Find(ID);
            return dbEntry;

        }

        public bool Insert(ProductCategory model)
        {
            ProductCategory dbEntry = context.ProductCategories.Find(model.ID);
            if (dbEntry != null) return false;
            context.ProductCategories.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Update(ProductCategory model)
        {
            ProductCategory dbEntry = context.ProductCategories.Find(model.ID);
            if (dbEntry == null) return false;
            dbEntry.ID = model.ID;
            dbEntry.Name = model.Name;
            dbEntry.MetaTitle = model.MetaTitle;
            dbEntry.DisplayOrder = model.DisplayOrder;
            dbEntry.Status = model.Status;
            dbEntry.ParentID = model.ParentID;
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(ProductCategory model)
        {
            ProductCategory dbEntry = context.ProductCategories.Find(model.ID);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.ProductCategories.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}