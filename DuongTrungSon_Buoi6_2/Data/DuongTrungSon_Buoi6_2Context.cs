using Microsoft.EntityFrameworkCore;

public class DuongTrungSon_Buoi6_2Context(DbContextOptions<DuongTrungSon_Buoi6_2Context> options) : DbContext(options)
{
    public DbSet<DuongTrungSon_Buoi6_2.Models.Movie> Movie { get; set; } = default!;
    public DbSet<DuongTrungSon_Buoi6_2.Models.Genre> Genre { get; set; } = default!;
}
