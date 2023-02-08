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
        private readonly ISearchService _searchService;

        public SerachController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        //Default SerachData + SearchBy DateTimeTo-DateTime-From , BillID
        [HttpPost("SearchData")]
        public async Task<IActionResult> SerachData([FromBody] ReqSearchModel data)
        {
            try
            {
                //Request Serach null = default SearchAll
                //TODO ขาดคิดเพิ่มเงื่อนไขการ search ผ่านวันที่ , billId , description
                if(!String.IsNullOrEmpty(data.DateTimeTo) && !String.IsNullOrEmpty(data.DateTimeFrom))
                {
                    var dataSearch = await _searchService.GetData(data.DateTimeTo, data.DateTimeFrom);
                    var cal = await _searchService.CalculateSum(dataSearch);
                    ResSearchResult result = new ResSearchResult();
                    List<SearchData> resSearchData = new List<SearchData>();
                    foreach (var item in dataSearch)
                    {
                        resSearchData.Add(new SearchData
                        {
                            tagVoucher= item.TagVoucher,
                            codeVoucher= item.CodeVoucher,
                            MainAccount= item.MainAccount,
                            Description= item.Description,
                            credit= item.Credit,
                            debit= item.Debit,
                            dateTimeTo= item.DateTimeTo.ToString("yyyy-MM-dd"),
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
                else //เผื่อกรณี defalut serach All 
                {
                    var dataSearch = await _searchService.GetData();
                    return Ok(dataSearch);
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /* //SerachDataById
        [HttpPost("SerachResult")]
        public async Task<IActionResult> SerachResult([FromBody] int billId)
        {
            var data = await _searchService.GetData(billId);
            var cal = await _searchService.CalculateSum(data);
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
*/
        [HttpPost("ExportExcel")]
        public async Task<IActionResult> ExportExcel([FromBody]ReqSearch dataSearch)
        {
            var data = await _searchService.GetData(dataSearch.dateTimeTo, dataSearch.dateTimeFrom);
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
