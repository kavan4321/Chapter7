using SQLite;

namespace Chapter7.Tables.Page6Table
{
    public class ShopifyTable
    {
        [Column("id")]
        [PrimaryKey]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
       
        [Column("price")]
        public int Price { get; set; }     
     
        [Column("stock")]
        public int Stock { get; set; }

        [Column("brand")]
        public string Brand { get; set; }     

        [Column("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
