using SQLite;

namespace DayPlanner.Models
{
    [Table("note")]
    public class NoteModel
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("ID")]
        public int ID { get; set; }

        [MaxLength(250)]
        [Column("Title")]
        public string Title { get; set; }

        [Column("Text")]
        public string Text { get; set; }

        [Column("CreatedOrUpdatedDate")]
        public DateTime CreatedOrUpdatedDate { get; set; } = DateTime.Now;

        [Column("ScheduledDate")]
        public DateTime ScheduledDate { get; set; } = DateTime.Now;
    }
}
