using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Bu ATTRIBUTE'dur
    public class ProductsController : ControllerBase  //chane == zincir
    {
        IProductService _productService;

        //Loosely couplet'dir asagidaki yeniki == Gevsek baglilik (Abstracta bagamliligi oldugu icin)
        //IoS Container == Inversion of Control (Deyisimin kontrolu) https://youtu.be/LZqMmvgCNx0?t=5509
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() //Basdakinin adi BreakPoint'di (Qirmizi nokte)
        {
            Thread.Sleep(1000);

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetById(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok( result);
            }
            return BadRequest(result);
        }
    }
}
