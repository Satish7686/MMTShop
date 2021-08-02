using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShopProduct.Models
{
    public class tblProductCategory
    {
        [Key]
        public int CategoryGid { get; set; }
        public string ProductCategory { get; set; }
    }
}
