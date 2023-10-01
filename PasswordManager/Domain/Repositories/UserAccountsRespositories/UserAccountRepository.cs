using CorePersistence.Repository;
using PasswordManager.Models;

namespace PasswordManager.Domain.Repositories.UserAccountsRespositories
{
    public class UserAccountRepository : Repository<UserAccounts, Entities>, IUserAccountRepository
    {
        public UserAccountRepository(Entities context) : base(context)
        {
        }
    }
}