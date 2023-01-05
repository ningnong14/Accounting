using Accounting.Interfaces;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddMainAccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IDebitCodeService _debitCodeService;
        public AddMainAccountController(ILogger<AccountController> logger, IDebitCodeService debitCodeService)
        {
            _logger = logger;
            _debitCodeService = debitCodeService;
        }
        //TODO API เส้นในการเก็บ Code รหัส debit 
        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
            var data = await _debitCodeService.GetDataAsync();
            return Ok(data);
        }
        [HttpPost("GetDataByCode")]
        public async Task<IActionResult> GetDataByCode([FromBody] DebitCodeModel data)
        {
            if (ModelState.IsValid)
            {
                var checkDupilcate = await _debitCodeService.GetDataByCode(data.Code);
                if(checkDupilcate is null)
                {
                    return Ok(data);
                }
                return BadRequest("Error DuplicateData(Codeซ้ำกัน)");
            }
            return BadRequest("Wrong Format");
        }
        [HttpPost("AddDebitCode")]
        public async Task<IActionResult> AddDebit([FromBody] DebitCodeModel detail)
        {
            if (ModelState.IsValid)
            {
                await _debitCodeService.InsertDataAsync(detail.Code, detail.Discription);
                return Ok(detail);
            }
            return BadRequest("Wrong Format");
        }
        [HttpPost("UpdateData")]
        public async Task<IActionResult> UpdateDebit([FromBody] DebitCodeModel data)
        {
            await _debitCodeService.UpdateDataAsync(1, data.Code, data.Discription);
            return Ok();
        }
        [HttpPost("DeleteData")]
        public async Task<IActionResult> DeleteDebit([FromBody] int id)
        {
            await _debitCodeService.DeleteDataAsync(id);
            return Ok();
        }
    }
}
