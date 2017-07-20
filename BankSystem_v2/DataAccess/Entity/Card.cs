namespace DataAccess.Entity
{
    using System;

    public class Card : BaseEntity

    {
        public string ParentUserId { get; set; }
        public string ParentAccountId { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime ValidThru { get; set; }

        public override string ToString()
        {
            return $"{CardNumber} {CardType} {Amount} {Currency} {ValidThru}";
        }
    }
}