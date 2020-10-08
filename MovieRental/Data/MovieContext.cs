using Microsoft.EntityFrameworkCore;
using MovieRental.Common;
using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) 
            : base(options)
        {
        }

        public DbSet<Movie> Movie {get; set;}

    }
}
