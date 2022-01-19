namespace Data.Entities
{
    public class HistoryReader
    {
        public int HistoryId { get; set; }
        public History History { get; set; }

        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}