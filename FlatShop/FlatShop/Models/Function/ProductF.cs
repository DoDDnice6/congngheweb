using FlatShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class ProductF
    {
        private MyDbContext context;

        public ProductF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        //trả về 1 đối tượng sản phẩm

        public Product FindEntity(long ID)
        {
            Product dbEntry = context.Products.Find(ID);
            return dbEntry;

        }

        public bool Insert(Product model)
        {
            Product dbEntry = context.Products.Find(model.ID);
            if (dbEntry != null) return false;
            context.Products.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Update(Product model)
        {
            Product dbEntry = context.Products.Find(model.ID);
            if (dbEntry == null) return false;
            dbEntry.ID = model.ID;
            dbEntry.Name = model.Name;
            dbEntry.Code = model.Code;
            dbEntry.MetaTitle = model.MetaTitle;
            dbEntry.Description = model.Description;
            dbEntry.Image = model.Image;
            dbEntry.MoreImages = model.MoreImages;
            dbEntry.Price = model.Price;
            dbEntry.PromotionPrice = model.PromotionPrice;
            dbEntry.IncludeVAT = model.IncludeVAT;
            dbEntry.CountryID = model.CountryID;
            dbEntry.Material = model.Material;
            dbEntry.Quantity = model.Quantity;
            dbEntry.BrandID = model.BrandID;
            dbEntry.CaterogyID = model.CaterogyID;
            dbEntry.Detail = model.Detail;
            dbEntry.Status = model.Status;
            dbEntry.Color = model.Color;
            dbEntry.Size = model.Size;
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(Product model)
        {
            Product dbEntry = context.Products.Find(model.ID);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.Products.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}