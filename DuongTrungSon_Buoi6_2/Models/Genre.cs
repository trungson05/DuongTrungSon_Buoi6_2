using System.ComponentModel.DataAnnotations;

namespace DuongTrungSon_Buoi6_2.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required(ErrorMessage ="Phai nhap ten the loai")]
        public string? GenreName { get; set; }
    }
}
