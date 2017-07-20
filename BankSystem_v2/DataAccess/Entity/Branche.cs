namespace DataAccess.Entity
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WorkDays { get; set; }
        public string WorkTime { get; set; }
        public string ImageUrl { get; set; }
    }
}