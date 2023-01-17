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
        private readonly ISerachService _serachService;
        public RecordAccountingController(IRecordAccountingService recordAccount, ISerachService serachService)
        {
            _recordAccount = recordAccount;
            _serachService = serachService;
        }

        [HttpPost("InsertRecordAccount")]
        public async Task<IActionResult> CreateRecordAccount([FromBody] List<ReqAccountRecordModel> data)
        {
            try
            {
                ResService res = new ResService();
                if (data == null)
                {
                    res.status = "400";
                    res.message = "Error Cant InsertData";
                    return BadRequest(data);
                }
                var insertdata = await _recordAccount.InsertData(data);
                res.status = "200";
                res.message = "Insert Success";
                res.result = insertdata;
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("CalDebit")]
        public async Task<IActionResult> CalDebit([FromBody] List<ReqAccountRecordModel> data)
        {
            
            return Ok();
        }
    }
}
