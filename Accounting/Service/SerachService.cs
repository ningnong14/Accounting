using Accounting.Interfaces;
using Accounting.Models;
using Accounting.Models.Model;
using Accounting.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Data;

namespace Accounting.Service
{
    public class SerachService : ISerachService
    {
        private readonly IRepository<BillRecord> _billRecordRepository;

        public SerachService(IRepository<BillRecord> billRecordRepository) 
        {
            _billRecordRepository = billRecordRepository;
        }

        //TODO 1. Cal Debit , Cal Credit , Balance 2. show data from query 3.export excel

        public async Task<List<BillRecord>> GetData(int billId)
        {
            var Serachdata = new BillRecordSpecification(billId);
            var data = await _billRecordRepository.ListAsync(Serachdata);
            return data;
 
        }

        public async Task<ResCalculateModel> CalculateSum(List<BillRecord> billData)
        {
            try
            {
                //TODO แก้ไข QUERY WHERE ด้วยข้อมูลที่กรอกเข้ามา SERACH
                var data = billData;
                if(data == null) { throw new ArgumentNullException("CalculdateSum received a null argument!"); }
                int? calCredit = 0;
                int? calDebit = 0;
                int? Balance = 0;
                foreach(var item in data)
                {
                    calCredit += item.Credit;
                    calDebit += item.Debit;
                    Balance = calDebit - calCredit;
                }
                ResCalculateModel result = new ResCalculateModel()
                {
                    TotalCredit = calCredit,
                    TotalDebit = calDebit,
                    Balance = Balance
                };
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ImportExcelModel>> ImportExcel(IFormFile file)
        {
            try
            {
                var list = new List<ImportExcelModel>();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        //TODO แก้ไขการวนลูปข้อมูล
                        for (int row = 2; row <= rowcount; row++)
                        {
                            list.Add(new ImportExcelModel {
                                Date = DateTime.Parse(worksheet.Cells[row, 1].Value.ToString()),
                                Voucher = worksheet.Cells[row, 2].Value.ToString(),
                                MainAccount = worksheet.Cells[row, 3].Value.ToString(),
                                Description = worksheet.Cells[row, 4].Value.ToString(),
                                Debit = int.Parse(worksheet.Cells[row, 5].Value.ToString()),
                                Credit = int.Parse(worksheet.Cells[row, 6].Value.ToString()),
                            });
                        }
                        //TODO Update DB
                    }
                }
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

/*        public async Task<Stream> ExportExcel()
        {
            try
            {
                var a = await _billRecordRepository.ListAsync();
                DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(a), (typeof(DataTable)));
                Stream stream = new MemoryStream();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells.LoadFromDataTable(table, true, OfficeOpenXml.Table.TableStyles.Light8);
                    package.Save();
                }
                stream.Position = 0;
                string excelName = "aaa.xlsx";
                return stream;

            }
            catch (Exception ex)
            {

            }
        }*/


    }
}
