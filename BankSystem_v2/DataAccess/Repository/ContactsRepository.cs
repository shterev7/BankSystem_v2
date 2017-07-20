namespace DataAccess.Repository
{
    using Entity;
    using System.Collections.Generic;
    using System.Linq;

    public class ContactsRepository : BaseRepository<Contact>
    {
        public List<Contact> GetAll(string parentUserId)
        {
            return Items.Where(i => i.ParentUserId == parentUserId).ToList();
        }
    }
}