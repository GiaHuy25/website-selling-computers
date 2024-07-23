using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebprojectCK.Models
{
    public class Brands
    {
        [Key]
        public long brandID { get; set; }
        public string brandName { get; set; }
        public long categoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}