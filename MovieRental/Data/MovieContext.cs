using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental.Data
{
    public class MovieContext : IdentityDbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) 
            : base(options)
        {
        }

        public DbSet<Movie> Movie {get; set;}

    }
}
