namespace DataAccess.Repository
{
    using System.Data.Entity;
    using Entity;

    public sealed class BankSystemDbContext : DbContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<BankAccount> BankAccounts { get; set; }
        public IDbSet<Card> Cards { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }
        public IDbSet<Branch> Branches { get; set; }

        public BankSystemDbContext() : base("BankSystemv2String")
        {
            Users = Set<User>();
            Cards = Set<Card>();
            Transactions = Set<Transaction>();
            Branches = Set<Branch>();
        }
    }
}