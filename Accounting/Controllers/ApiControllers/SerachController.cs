using Accounting.Interfaces;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;

namespace Accounting.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerachController : Controller
    {
        private readonly ISerachService _serachService;

        public SerachController(ISerachService serachService)
        {
            _serachService = serachService;
        }

        [HttpPost("SerachResult")]
        public async Task<IActionResult> SerachResult([FromBody] int billId)
        {
            var data = await _serachService.GetData(billId);
            var cal = await _serachService.CalculateSum(data);
            ResSearchResult result = new ResSearchResult();
            List<SearchData> resSearchData = new List<SearchData>();
            foreach (var item in data)
            {
                resSearchData.Add(new SearchData
                {
                    BillId = item.BillId,
                    Date = item.Date.ToString(),
                    Voucher = item.Voucher,
                    MainAccount = item.MainAccount,
                    Description = item.Description,
                    Debit = item.Debit,
                    Credit = item.Credit,
                });
            }
            result.status = "200";
            result.messageCode = "OK";
            result.message = "Call Service SerachResult Success";
            result.data = resSearchData;
            result.TotalDebit = cal.TotalDebit;
            result.TotalCredit = cal.TotalCredit;
            result.Balance = cal.Balance;
            return Ok(result);
        }

        [HttpPost("ExportExcel")]
        public async Task<IActionResult> ExportExcel([FromBody] int billId)
        {
            var data = await _serachService.GetData(billId);
            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(data), (typeof(DataTable)));
            Stream stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells.LoadFromDataTable(table, true, OfficeOpenXml.Table.TableStyles.Light8);
                package.Save();
            }
            stream.Position = 0;
            string excelName = "accounting.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
