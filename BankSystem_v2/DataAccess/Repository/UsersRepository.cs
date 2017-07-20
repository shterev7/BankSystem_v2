namespace DataAccess.Repository
{
    using Entity;
    using System.Linq;

    public class UsersRepository : BaseRepository<User>
    {
        public User GetByUsernameAndPassword(string username, string password)
        {
            return Items.FirstOrDefault(
                i => i.Username == username && i.Password == password);
        }
    }
}
