using Accounting.Interfaces;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordAccountingController : Controller
    {
        private readonly IRecordAccountingService _recordAccount;
        public RecordAccountingController(IRecordAccountingService recordAccount)
        {
            _recordAccount = recordAccount;
        }

        [HttpPost("RecordAccount")]
        public async Task<IActionResult> CreateRecordAccount([FromBody] List<ReqAccountRecordModel> data)
        {
            await _recordAccount.InsertData(data);
            return Ok();
        }
    }
}
