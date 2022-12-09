using Accounting.Models;
using Ardalis.Specification;

namespace Accounting.Specifications
{
    public class UserLoginSpecification : Specification<UserLogin>, ISingleResultSpecification<UserLogin>
    {
        public UserLoginSpecification(string username) 
        {
            Query
                .Where(name => name.Username.Equals(username));
        }
    }
}
