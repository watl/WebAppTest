using Application.Interface;
using Core.Entities;
using Infraestructura.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public RateController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Rates.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Rates.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet()]
        [Route("GetByDateRate/{daterate}")]
        public async Task<IActionResult> GetByDayRate(DateTime daterate)
        {
            var data = await unitOfWork.Rates.GetByDateRateAsync(daterate);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet()]
        [Route("GetByMontRate/{initdate}/{finaldate}")]
        public async Task<IActionResult> GetByMontRate(DateTime initdate, DateTime finaldate)
        {
            var data = await unitOfWork.Rates.GetByMonthRateAsync(initdate,finaldate);
            if (data == null) return Ok();
            return Ok(data);
        }



        [HttpPost]
        public async Task<IActionResult> Add(Rate rate)
        {
            var data = await unitOfWork.Rates.AddAsync(rate);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Rates.DeleteAsync(id);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Rate rate)
        {
            var data = await unitOfWork.Rates.UpdateAsync(rate);
            return Ok(data);
        }


    }
}
