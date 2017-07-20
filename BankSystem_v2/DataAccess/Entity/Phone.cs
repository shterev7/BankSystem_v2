namespace DataAccess.Entity
{
    public class Phone : BaseEntity
    {
        public string ParentContactId { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return PhoneNumber;
        }
    }
}
