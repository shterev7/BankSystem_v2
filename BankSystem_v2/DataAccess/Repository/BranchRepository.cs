namespace DataAccess.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Entity;

    public class BranchRepository : BaseRepository<Branch>
    {
        public List<Branch> GetAll()
        {
            return Items.ToList();
        }
    }
}