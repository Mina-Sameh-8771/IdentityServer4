using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Client.Models;

namespace Movie.Client.Data
{
    public class MovieClientContext : DbContext
    {
        public MovieClientContext (DbContextOptions<MovieClientContext> options)
            : base(options)
        {
        }

        public DbSet<Movie.Client.Models.MovieModel> MovieModel { get; set; }
    }
}
