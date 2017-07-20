namespace DataAccess.Entity
{
    using System;

    public class Transaction : BaseEntity
    {
        public string ParentUserId { get; set; }

        public int Type { get; set; }
        public DateTime Date { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}