using Accounting.Models.Model;

namespace Accounting.Interfaces
{
    public interface ICalculateService
    {
        ResCalculateModel CheckCalculateDebitAndCredit(List<ReqAccountRecordModel> cal);
    }
}
