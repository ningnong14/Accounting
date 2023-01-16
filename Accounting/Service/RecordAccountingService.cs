using Accounting.Interfaces;
using Accounting.Models;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Accounting.Service
{
    public class RecordAccountingService : IRecordAccountingService
    {
        private readonly IRepository<RecordAccounting> _recordAccRepository;
        public RecordAccountingService(IRepository<RecordAccounting> recordAccRepositoty)
        {
            _recordAccRepository= recordAccRepositoty;
        }

        public async Task<string> InsertData(List<ReqAccountRecordModel> reqData)
        {
            foreach (var req in reqData)
            {
                RecordAccounting recordData1 = new RecordAccounting();
                recordData1.Description = req.Description;
                recordData1.DateTimeTo = req.DateTimeTo;
                recordData1.MainAccount = req.MainAccount;
                recordData1.Debit = req.Debit;
                recordData1.Credit = req.Credit;
                recordData1.DateTimeFrom = DateTime.Now;
                recordData1.CodeVoucher = "GSJ";

                await _recordAccRepository.AddAsync(recordData1);
            }
            return "Ok";
        }
    }
}
