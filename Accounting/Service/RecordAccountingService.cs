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
        private readonly IRepository<TagVoucher> _tagVoucherRepository;
        public RecordAccountingService(IRepository<RecordAccounting> recordAccRepositoty, IRepository<TagVoucher> tagVoucherRepository)
        {
            _recordAccRepository = recordAccRepositoty;
            _tagVoucherRepository = tagVoucherRepository;
        }

        public async Task<List<RecordAccounting>> InsertData(List<ReqAccountRecordModel> reqData, int tagVoucher)
        {
            List<RecordAccounting> insertData = new List<RecordAccounting>();
            foreach (var req in reqData)
            {
                DateTime convertDateTime = Convert.ToDateTime(req.dateTime);
                RecordAccounting recordData = new RecordAccounting();
                recordData.TagVoucher = tagVoucher;
                recordData.Description = req.description;
                recordData.DateTimeTo = convertDateTime;
                recordData.MainAccount = req.mainAccount;
                recordData.Debit = req.debit;
                recordData.Credit = req.credit;
                recordData.CodeVoucher = req.voucher;

                await _recordAccRepository.AddAsync(recordData);
                insertData.Add(recordData);
            }
            return insertData;
        }
        public async Task<TagVoucher> GetTagVoucher()
        {
            TagVoucher tagVoucher = new TagVoucher()
            {
                DateTime = DateTime.Now,
            };
            return await _tagVoucherRepository.AddAsync(tagVoucher);
        }
    }
}
