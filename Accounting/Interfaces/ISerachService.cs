using Accounting.Models;
using Accounting.Models.Model;

namespace Accounting.Interfaces
{
    public interface ISearchService
    {
        Task<List<RecordAccounting>> GetData();
        Task<List<BillRecord>> GetData(int billId);
        Task<List<RecordAccounting>> GetData(string dateTimeTo, string dateTimeFrom);
        Task<ResCalculateModel> CalculateSum(List<RecordAccounting> billData);
        Task<List<ImportExcelModel>> ImportExcel(IFormFile file);
   /*     Task<Stream> ExportExcel();*/

    }
}
