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

        public async Task<List<RecordAccounting>> InsertData(List<ReqAccountRecordModel> reqData)
        {
            List<RecordAccounting> insertData = new List<RecordAccounting>();
            foreach (var req in reqData)
            {
                RecordAccounting recordData = new RecordAccounting();
                recordData.Description = req.Description;
                recordData.DateTimeTo = req.DateTimeTo;
                recordData.MainAccount = req.MainAccount;
                recordData.Debit = req.Debit;
                recordData.Credit = req.Credit;
                recordData.DateTimeFrom = DateTime.Now;
                recordData.CodeVoucher = "GSJ";

                await _recordAccRepository.AddAsync(recordData);
                insertData.Add(recordData);
            }
            return insertData;
        }
    }
}
