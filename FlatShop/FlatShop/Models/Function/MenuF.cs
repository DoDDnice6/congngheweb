using FlatShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class MenuF
    {
        private MyDbContext context;

        public MenuF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<Menu> Menus
        {
            get { return context.Menus; }
        }

        //trả về 1 đối tượng sản phẩm

        public Menu FindEntity(long ID)
        {
            Menu dbEntry = context.Menus.Find(ID);
            return dbEntry;

        }

        public bool Insert(Menu model)
        {
            Menu dbEntry = context.Menus.Find(model.ID);
            if (dbEntry != null) return false;
            context.Menus.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Update(Menu model)
        {
            Menu dbEntry = context.Menus.Find(model.ID);
            if (dbEntry == null) return false;
            dbEntry.ID = model.ID;
            dbEntry.Link = model.Link;
            dbEntry.Status = model.Status;
            dbEntry.DisplayOrder = model.DisplayOrder;
            dbEntry.TypeID = model.TypeID;
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(Menu model)
        {
            Menu dbEntry = context.Menus.Find(model.ID);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.Menus.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}