namespace FlatShop.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }

        public int? Status { get; set; }

        public DateTime? OrderDate { get; set; }

        [StringLength(50)]
        public string ShipAddress { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
