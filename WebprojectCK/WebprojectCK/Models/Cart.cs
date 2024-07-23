using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebprojectCK.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set;  }
        public int productID { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
       
    }
}