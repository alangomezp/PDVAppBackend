using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using BusinessLogic.Domain.Services.Definition;
using BusinessLogic.Domain.Services.Implementation;
using BusinessLogic.Persistence.Repository.Definition;
using Microsoft.AspNetCore.Mvc;

namespace PDVApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        
        private readonly ILogger<Payments> _logger;
        private readonly IPaymentsServices _paymentService;
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentController(ILogger<Payments> logger, IPaymentsServices paymentService, IPaymentsRepository paymentsRepository)
        {
            _logger = logger;
            _paymentService = paymentService;
            _paymentsRepository = paymentsRepository;
        }

        [HttpGet(Name = "GetAllPayments")]
        public IList<Payments> Get()
        {
            return _paymentsRepository.GetAll();

        }

        [HttpPost(Name = "Pay")]
        public Result Post([FromBody] PaymentFactory paymentFactory)
        {
            return _paymentService.Pay(paymentFactory);

        }

        [HttpPut(Name = "UpdatePayment")]
        public Result Put([FromQuery] Guid id, [FromBody] PaymentEdited paymentEdited)
        {
            return _paymentService.Update(id, paymentEdited);
        }

        [HttpDelete(Name = "DeletePayment")]
        public Result Delete([FromQuery] Guid id)
        {
            return _paymentService.Delete(id);
        }


    }
}