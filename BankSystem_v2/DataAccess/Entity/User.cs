namespace DataAccess.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Egn { get; set; }
        public string Address { get; set; }
       

        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName} {Egn} {Address}";
        }
    }
}
