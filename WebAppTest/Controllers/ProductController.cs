using Application.Interface;
using Core.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace WebAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase 
    {
        private readonly IUnitOfWork unitOfWork;
      

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;         
        }

  

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            var data = await unitOfWork.Products.AddProductAsync(product);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetActiveProductsAsync")]
        public async Task<IActionResult> GetActiveProductsAsync()
        {
            var data = await unitOfWork.Products.GetActiveProductsAsync();
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetBySkuAsync")]
        public async Task<IActionResult> GetBySkuAsync(string texto)
        {
            var data = await unitOfWork.Products.GetBySkuAsync(texto);
            if (data == null) return Ok();
            return Ok(data);
        }


        [HttpGet]
        [Route("GetByDescriptionAsync")]
        public async Task<IActionResult> GetByDescriptionAsync(string texto)
        {
            var data = await unitOfWork.Products.GetByDescriptionAsync(texto);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Products.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Products.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var data = await unitOfWork.Products.AddAsync(product);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Products.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var data = await unitOfWork.Products.UpdateAsync(product);
            return Ok(data);
        }
    }
}
