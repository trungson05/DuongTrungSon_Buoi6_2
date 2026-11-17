using System.ComponentModel.DataAnnotations;

namespace DuongTrungSon_Buoi6_2.Models
{
    public class MovieViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime ReleseDate { get; set; }
        public decimal Price { get; set; }
        public string? GenreName { get; set; }
      
    }
}
