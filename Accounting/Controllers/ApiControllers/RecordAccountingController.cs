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
        private readonly ICalculateService _calculateService;
        public RecordAccountingController(IRecordAccountingService recordAccount, ICalculateService calculateService)
        {
            _recordAccount = recordAccount;
            _calculateService = calculateService;
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
                //ดึงเลข Tag_VOUCHER ในแต่ละครั้งของการบันทึก   1 Voucher จะมี กี่ transaction ก็ได้ และ การบันทึกทุกครั้ง debit = credit(เช็คจากหน้าบ้าน)
                var getTagVoucher = await _recordAccount.GetTagVoucher();
                // insert ข้อมูลโดยอิงจาก transactionที่ส่งเข้ามา
                var insertdata = await _recordAccount.InsertData(data,getTagVoucher.TagVoucher1);
                res.status = "200";
                res.message = "Insert Success";
                res.result = insertdata;
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("CalculateService")]
        public IActionResult CalDebit([FromBody] List<ReqAccountRecordModel> data)
        {
            if(data == null) { return BadRequest(); }
            var calData = _calculateService.CheckCalculateDebitAndCredit(data);
            return Ok(calData);
        }
    }
}
