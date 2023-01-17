using Accounting.Models;
using Accounting.Models.Model;

namespace Accounting.Interfaces
{
    public interface ISearchService
    {
        Task<List<BillRecord>> GetData();
        Task<List<BillRecord>> GetData(int billId);
        Task<List<BillRecord>> GetData(DateTime dateTimeTo, DateTime dateTimeFrom);
        Task<ResCalculateModel> CalculateSum(List<BillRecord> billData);
        Task<List<ImportExcelModel>> ImportExcel(IFormFile file);
   /*     Task<Stream> ExportExcel();*/

    }
}
