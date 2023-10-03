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
    public class BagFundController : ControllerBase
    {
        
        private readonly ILogger<BagFund> _logger;
        private readonly IBagFundServices _bagFundService;
        private readonly IBagFundRepository _bagFundRepository;

        public BagFundController(ILogger<BagFund> logger, IBagFundServices bagFundService, IBagFundRepository bagFundRepository)
        {
            _logger = logger;
            _bagFundService = bagFundService;
            _bagFundRepository = bagFundRepository;
        }

        [HttpGet(Name = "GetAllBagFunds")]
        public IList<BagFund> Get()
        {
            return _bagFundRepository.GetAll();

        }

        [HttpPost(Name = "RegisterBagFund")]
        public Result Post([FromBody] BagFundFactory bagFundFactory)
        {
            return _bagFundService.Register(bagFundFactory);

        }

        [HttpPut(Name = "UpdateBagFund")]
        public Result Put([FromQuery] Guid id, [FromBody] BagFundEdited bagFundEdited)
        {
            return _bagFundService.Update(id, bagFundEdited);
        }

        [HttpDelete(Name = "DeleteBagFund")]
        public Result Delete([FromQuery] Guid id)
        {
            return _bagFundService.Delete(id);
        }


    }
}