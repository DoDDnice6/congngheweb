using FlatShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class OrderF
    {
        private MyDbContext context;

        public OrderF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<Order> Orders
        {
            get { return context.Orders; }
        }

        //trả về 1 đối tượng sản phẩm

        public Order FindEntity(long ID)
        {
            Order dbEntry = context.Orders.Find(ID);
            return dbEntry;

        }

        public long Insert(Order model)
        {
            Order dbEntry = context.Orders.Find(model.ID);
            if (dbEntry != null) return -1;
            context.Orders.Add(model);
            context.SaveChanges();
            return model.ID;
        }

        public bool Update(Order model)
        {
            Order dbEntry = context.Orders.Find(model.ID);
            if (dbEntry == null) return false;
            dbEntry.ID = model.ID;
            dbEntry.CustomerEmail = model.CustomerEmail;
            dbEntry.OrderDate = model.OrderDate;
            dbEntry.ShipAddress = model.ShipAddress;
            dbEntry.TotalPrice = model.TotalPrice;
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(Order model)
        {
            Order dbEntry = context.Orders.Find(model.ID);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.Orders.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}