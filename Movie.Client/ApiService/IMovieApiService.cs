using Movie.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Client.ApiService
{
    public interface IMovieApiService
    {
        Task<IEnumerable<MovieModel>> GetMovies();
    }
}
