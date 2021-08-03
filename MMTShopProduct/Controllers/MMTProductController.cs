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
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    
    public class MMTProductController : ControllerBase
    {
        public readonly AppDbContext _context;

        public MMTProductController(AppDbContext context)
        {
           _context = context;

        }

        [HttpGet("Feature")]
        public IActionResult featuredProducts()
        {
            string _storeProc = "exec SP_ProductsFeatured";
            try
            {
                var result = _context.tblProduct.FromSqlRaw(_storeProc);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
           
        }

        [HttpGet("Category")]
        [MapToApiVersion("2.0")]
        public IActionResult Categories()
        {
            string _storeProc = "exec SP_ProductsCategories";
            try
            {
                var result = _context.tblProductCategory.FromSqlRaw(_storeProc);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
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
                catch (Exception ex)
                {
                  return BadRequest(ex);
                }
         
           
        }
        
    }
}
