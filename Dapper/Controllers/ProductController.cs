using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Products.GetAllAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var data = await _unitOfWork.Products.Add(product);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Products.GetById(id);
            if (data == null) { return Ok(); }
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Products.DeleteById(id);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var data = await _unitOfWork.Products.Update(product);
            return Ok(data);
        }
    }
}