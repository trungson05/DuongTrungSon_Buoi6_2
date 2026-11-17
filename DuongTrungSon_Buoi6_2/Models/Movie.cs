using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuongTrungSon_Buoi6_2.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200,MinimumLength =2,ErrorMessage ="title must me")]
        public string? Title { get; set; }
        public DateTime ReleseDate { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
