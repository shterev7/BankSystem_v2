namespace DataAccess.Repository
{
    using Entity;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonesRepository : BaseRepository<Phone>
    {
        public List<Phone> GetAll(string parentContactId)
        {
            return Items.Where(i => i.ParentContactId == parentContactId).ToList();
        }
    }
}