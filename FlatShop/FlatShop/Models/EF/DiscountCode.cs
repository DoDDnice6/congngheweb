namespace FlatShop.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscountCode")]
    public partial class DiscountCode
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public decimal? Redution { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
