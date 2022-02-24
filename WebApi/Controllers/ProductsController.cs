using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        } 
        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpGet("getlistbyunitid")]
        public IActionResult GetListByUnitId(int categoryId)
        {
            var result = _productService.GetListByUnitId(categoryId);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
