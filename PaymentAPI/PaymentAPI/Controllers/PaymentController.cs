using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Helper;
using PaymentAPI.Models;
using PaymentAPI.Request;
using PaymentAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _service;
        public PaymentController(PaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payment = await _service.GetAll();
            return Ok(payment);
        }

        [HttpGet("{id}", Name = "GetPayment")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var payment = await _service.GetById(id);
            return Ok(payment);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> EditPayment(string id, PaymentDetail paymentDetail)
        {
            var payment = await _service.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }

            await _service.Update(payment.Id, paymentDetail);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentCreateRequest request)
        {
            
            PaymentDetail payment = new PaymentDetail
            {
                Id = ApiHelper.GetRandomId(),
                CardOwnerName = request.CardOwnerName,
                CardNumber = request.CardNumber,
                ExpirationDate = request.ExpirationDate

            };
            await _service.Add(payment);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(string id)
        {
            var payment = await _service.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }

            await _service.Delete(id);
            return Ok();
        }


    }
}
