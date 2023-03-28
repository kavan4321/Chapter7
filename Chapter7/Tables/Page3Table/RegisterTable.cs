using SQLite;

namespace Chapter7.Tables.Page3Table
{
    [Table("Details")]
     public class RegisterTable
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
      
        [Column("Username")]
        public string UserName { get; set; }
        [Column("Password")]
        public string Password { get; set; }
    }
}
