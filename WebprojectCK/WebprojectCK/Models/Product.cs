using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebprojectCK.Models
{
    public class Product
    {
        [Key]
        public int productID { get; set; }
        public string productName { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Nullable<decimal> price { get; set; }
        public Nullable<System.DateTime> createdate { get; set; }
        public string availabilityStatus { get; set; }
        public string img { get; set; }
        public Nullable<long> categoryID { get; set; }
        public Nullable<long> brandID { get; set; }
        public virtual Brands Brands { get; set; }
        public virtual Category Category { get; set; }
    }
}