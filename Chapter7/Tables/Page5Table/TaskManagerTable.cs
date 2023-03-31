
using SQLite;

namespace Chapter7.Tables.Page5Table
{
    public class TaskManagerTable
    {
        [AutoIncrement]
        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }

        [Unique]
        [Column("Name")]
        public string TaskName { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("CompletionTime")]
        public DateTime CompletionDate { get; set; }

        [Column("StartTime")]
        public DateTime StartTime { get; set; }

        [Column("EndTime")]
        public DateTime EndTime { get; set; }

    }

}
