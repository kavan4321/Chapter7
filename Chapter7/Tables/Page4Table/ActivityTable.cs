
using SQLite;

namespace Chapter7.Tables.Page4Table
{
    [Table("ActivityDetail")]
    public class ActivityTable
    {
        [AutoIncrement]
        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }

        [Unique, Column("ActivityName")]
        public string ActivityName { get;set; }

        [Column("DueDate")]
        public DateTime DueDate { get; set; }
       
        [Column("IsComplete")]
        public bool IsComplete { get; set; }
    }
}
