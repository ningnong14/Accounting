using Accounting.Models;

namespace Accounting.Interfaces
{
    public interface IDebitCodeService
    {
        Task<List<CodeDebit>> GetDataAsync();
        Task InsertDataAsync(string code, string description);
        Task InserDataAsync(CodeDebit data);
        Task UpdateDataAsync(int id, string code, string description);
        Task UpdateDataAsync(CodeDebit data);
        Task DeleteDataAsync(int id);
        Task DeletDataAsync(CodeDebit data);

    }
}
