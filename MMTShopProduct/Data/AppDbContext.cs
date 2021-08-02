using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MMTShopProduct.Models;

namespace MMTShopProduct.Data
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<tblProduct> tblProduct { get; set; }
        public DbSet<tblProductCategory> tblProductCategory { get; set; }

    }
}
