using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebprojectCK.Models
{
    public class Category
    {
        [Key]
        public long categoryID { get; set; }
        public string categoryName { get; set; }
    }
}