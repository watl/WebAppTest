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

        private readonly ProductRepository productRepository;
        private readonly Tipo_Cambio_BCNSoap tipo_Cambio_BCNSoap;

        public ProductController(IUnitOfWork unitOfWork, Tipo_Cambio_BCNSoap tipo_Cambio_BCNSoap)
        {
            this.unitOfWork = unitOfWork;
            this.tipo_Cambio_BCNSoap = tipo_Cambio_BCNSoap; 
        }

        [HttpPost("GetTipoCambio")]
        public IActionResult GetTipoCambioDia(int dia, int mes, int anio)
        {   
            var response = tipo_Cambio_BCNSoap.RecuperaTC_Dia(dia, mes, anio);
            return Ok(response);

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
