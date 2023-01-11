using Application.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;


        public FacturasController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpPost]
        [Route("AgregarFactura")]
        public async Task<IActionResult> AddFacturaAsync(Factura factura)
        {
            var data = await unitOfWork.Factura.AddAsync(factura);
            return Ok(data);
        }

        [HttpGet]
        [Route("ObtenerFacturasAsync")]
        public async Task<IActionResult> GetFacturasAsync()
        {
            var data = await unitOfWork.Factura.ObtenerFacturasAsync();
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Factura.DeleteAsync(id);
            return Ok(data);
        }

    }
}
