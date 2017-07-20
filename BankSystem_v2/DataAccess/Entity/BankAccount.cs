namespace DataAccess.Entity
{
    public class BankAccount : BaseEntity
    {
        public string ParentUserId { get; set; }

        public string Iban { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"{Iban} {Amount}{Currency}";
        }
    }
}