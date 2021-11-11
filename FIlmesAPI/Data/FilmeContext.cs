using FIlmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FIlmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> option) : base(option)
        {

        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }
    }
}
