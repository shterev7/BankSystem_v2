namespace DataAccess.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Entity;

    public class AccountRepository : BaseRepository<BankAccount>
    {
        public List<BankAccount> GetAll(string userId)
        {
            return Items.Where(x => x.ParentUserId.Equals(userId)).ToList();
        }
    }
}