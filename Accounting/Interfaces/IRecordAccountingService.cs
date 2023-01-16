using Accounting.Models.Model;

namespace Accounting.Interfaces
{
    public interface IRecordAccountingService
    {
        Task<string> InsertData(List<ReqAccountRecordModel> reqData);
    }
}
