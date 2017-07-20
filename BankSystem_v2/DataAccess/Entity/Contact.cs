namespace DataAccess.Entity
{
    public class Contact : BaseEntity
    {
        public string ParentUserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", FullName, Email);
        }
    }
}
