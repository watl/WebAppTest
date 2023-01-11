using Application.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;


        public DetalleFacturaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// permite ingresar detalle de factura
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarDetalleFactura")]
        public async Task<IActionResult> AddDetalleFacturaAsync(DetalleFactura detalle)
        {
            var data = await unitOfWork.DetalleFactura.AgregarDetalleFacturaAsync(detalle);
            return Ok(data);
        }


    }
}
