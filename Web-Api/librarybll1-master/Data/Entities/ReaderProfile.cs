namespace Data.Entities
{
    public class ReaderProfile : BaseEntity
    {
        public int ReaderId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}