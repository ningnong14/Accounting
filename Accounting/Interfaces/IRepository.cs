using Ardalis.Specification;
namespace Accounting.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
