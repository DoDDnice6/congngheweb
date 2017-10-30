using FlatShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.Function
{
    public class OrderDetailF
    {
        private MyDbContext context;

        public OrderDetailF()
        {
            context = new MyDbContext();
        }
        //trả về toàn bộ dữ liệu
        public IQueryable<OrderDetail> OrderDetails
        {
            get { return context.OrderDetails; }
        }

        //trả về 1 đối tượng sản phẩm

        public OrderDetail FindEntity(long ID)
        {
            OrderDetail dbEntry = context.OrderDetails.Find(ID);
            return dbEntry;

        }

        public bool Insert(OrderDetail model)
        {
            OrderDetail dbEntry = context.OrderDetails.Find(model.ID);
            if (dbEntry != null) return false;
            context.OrderDetails.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Update(OrderDetail model)
        {
            OrderDetail dbEntry = context.OrderDetails.Find(model.ID);
            if (dbEntry == null) return false;
            dbEntry.ID = model.ID;
            dbEntry.OrderID = model.OrderID;
            dbEntry.ProductID = model.ProductID;
            dbEntry.UnitPrice = model.UnitPrice;
            dbEntry.Quantity = model.Quantity;
            // context.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return true;
        }

        public bool Delete(OrderDetail model)
        {
            OrderDetail dbEntry = context.OrderDetails.Find(model.ID);
            if (dbEntry == null) return false;
            //context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.OrderDetails.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}