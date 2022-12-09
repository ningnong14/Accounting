using Accounting.Models;
using Accounting.Models.Model;

namespace Accounting.Interfaces
{
    public interface ISerachService
    {
        Task<List<BillRecord>> GetData(int billId);
        Task<ResCalculateModel> CalculateSum(List<BillRecord> billData);
        Task<List<ImportExcelModel>> ImportExcel(IFormFile file);
   /*     Task<Stream> ExportExcel();*/

    }
}
