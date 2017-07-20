namespace DataAccess.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Entity;

    public class CardRepository : BaseRepository<Card>
    {
        public List<Card> GetAll(string accountId)
        {
            return Items.Where(x => x.ParentAccountId == accountId).ToList();
        }
    }
}