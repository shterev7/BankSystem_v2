namespace DataAccess.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Entity;

    public class TransactionRepository : BaseRepository<Transaction>
    {
        public List<Transaction> GetAll(string parentUserId)
        {
            return Items.Where(x => x.ParentUserId == parentUserId).ToList();
        }
    }
}