using Accounting.Interfaces;
using Accounting.Models;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Globalization;

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
                DateTime convertDateTime = Convert.ToDateTime(req.dateTime);
                RecordAccounting recordData = new RecordAccounting();
                recordData.Description = req.description;
                recordData.DateTimeTo = convertDateTime;
                recordData.MainAccount = req.mainAccount;
                recordData.Debit = req.debit;
                recordData.Credit = req.credit;
                recordData.CodeVoucher = "GSJ";

                await _recordAccRepository.AddAsync(recordData);
                insertData.Add(recordData);
            }
            return insertData;
        }
    }
}
