using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MMTShopProduct.Data;
using MMTShopProduct.Models;

namespace MMTShopProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MMTProductController : ControllerBase
    {
        public readonly AppDbContext _context;

        public MMTProductController(AppDbContext context)
        {
           _context = context;

        }

        [HttpGet("Feature")]
        public IEnumerable<tblProduct> featuredProducts()
        {
            string _storeProc = "exec SP_ProductsFeatured";
            return _context.tblProduct.FromSqlRaw(_storeProc);
        }

        [HttpGet("Category")]
        public IEnumerable<tblProductCategory> Categories()
        {
            string _storeProc = "exec SP_ProductsCategories";
            return _context.tblProductCategory.FromSqlRaw(_storeProc);
        }

        [HttpGet("ProductsByCategory")]
        public IActionResult ProductsByCategory( string category)
        {
            
                string _storeProc = "exec SP_ProductsByCategory @Category ";
               
                try
                { 
                    if (!string.IsNullOrEmpty(category))
                    { 
                        SqlParameter parameter = new SqlParameter("@Category", category);
                     var result = _context.tblProduct.FromSqlRaw(_storeProc, parameter);
                     return Ok(result);

                    }
                    else
                    {
                        return Ok("Please Select category");
                    }
                   
                }
                catch (Exception e)
                {
                  return BadRequest();
                }
         
           
        }
        
    }
}
