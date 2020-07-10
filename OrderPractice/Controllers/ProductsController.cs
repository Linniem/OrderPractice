using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderPractice.Data;
using OrderPractice.Models;
using OrderPractice.Services;

namespace OrderPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Products/Product1
        [HttpGet("{productName}")]
        public async Task<ActionResult<Product>> GetProduct(string productName)
        {
            return await productService.FindProduct(productName);
        }
    }
}
