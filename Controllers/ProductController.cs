using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testApp.BusinessLayer;
using testApp.Models;

namespace testApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class ProductController : ControllerBase
    {
        public readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        public IActionResult GetProductList()
        {
            try
            {
                var productList = _productManager.GetProductList().Result;
                return Ok(productList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong. Please contact the admin.");
            }
        }

        [HttpPost]
        public IActionResult PostProductList(Products products)
        {
            try
            {
                _productManager.PostProductList(products);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong. Please contact the admin.");
            }
        }
    }
}
