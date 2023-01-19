using Accounting.Models;
using Accounting.Models.Model;

namespace Accounting.Interfaces
{
    public interface IRecordAccountingService
    {
        Task<List<RecordAccounting>> InsertData(List<ReqAccountRecordModel> reqData,int tagVoucher);
        Task<TagVoucher> GetTagVoucher();
    }
}
