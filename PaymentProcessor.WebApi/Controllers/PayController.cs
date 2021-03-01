using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentProcessor.Models.DTO;
using PaymentProcessor.Services;

namespace PaymentProcessor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly ILogger<PayController> _logger;
        private readonly IPaymentRequestService _paymentRequestService;

        public PayController(IPaymentRequestService paymentRequestService, ILogger<PayController> logger)
        {
            _logger = logger;
            _paymentRequestService = paymentRequestService;
        }

        [HttpGet]
        public string Get()
        {
            return "Payment Processor is online";
        }

        [Route("ProcessPayment")]
        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentRequestDto paymentRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var paymentState = await _paymentRequestService.Pay(paymentRequest);
                    if (!(paymentState.PaymentState == PaymentStateEnum.Processed))
                        return StatusCode(400, "400 bad request");
                    return StatusCode(200, "200 Ok");
                }
                else
                    return StatusCode(400, "400 bad request");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "500 internal server error");
            }
        }
    }
}