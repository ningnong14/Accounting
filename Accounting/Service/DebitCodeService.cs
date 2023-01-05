using Accounting.Interfaces;
using Accounting.Models;
using Accounting.Specifications;

namespace Accounting.Service
{
    public class DebitCodeService : IDebitCodeService
    {
        private readonly ILogger<DebitCodeService> _logger;
        private readonly IRepository<CodeDebit> _codeDebit;
        public DebitCodeService(ILogger<DebitCodeService> logger,IRepository<CodeDebit> codeDebit)
        {
            _logger = logger;
            _codeDebit = codeDebit;
        }
        public async Task<List<CodeDebit>> GetDataAsync()
        {
            return await _codeDebit.ListAsync();
        }

        public async Task<CodeDebit> GetDataByCode(string code)
        {
            var searchSpec = new DebitCodeGetByCodeSpecification(code);
            var data = await _codeDebit.SingleOrDefaultAsync(searchSpec);
            if(data is null)
            {
                return null;
            }
            return data;
        }

        public async Task InsertDataAsync(string code, string description)
        {
            CodeDebit detailData = new CodeDebit
            {
                Date = DateTime.Now,
                Code = code,
                Description = description
            };
            await _codeDebit.AddAsync(detailData);
        }

        public async Task InserDataAsync(CodeDebit data)
        {
            await _codeDebit.AddAsync(data);
        }

        public async Task UpdateDataAsync(int id, string code, string description)
        {
            var updateSpec = new DebitCodeUpdateSpecification(id);
            var data = await _codeDebit.SingleOrDefaultAsync(updateSpec);
            if(data != null)
            {
                data.Code = code;
                data.Description = description;

                await _codeDebit.UpdateAsync(data);
            }
        }

        public async Task UpdateDataAsync(CodeDebit data)
        {
            await _codeDebit.UpdateAsync(data);
        }

        public async Task DeleteDataAsync(int id)
        {
            var DeleteSpec = new DebitCodeUpdateSpecification(id);
            var data = await _codeDebit.SingleOrDefaultAsync(DeleteSpec);
            if(data != null)
            {
                await _codeDebit.DeleteAsync(data);
            }

        }
        public async Task DeletDataAsync(CodeDebit data)
        {
            await _codeDebit.DeleteAsync(data);
        }

    }
}
