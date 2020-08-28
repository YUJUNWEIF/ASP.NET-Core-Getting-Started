using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.models;

namespace CoreDemo.Services
{
    public interface IMovieService
    {
        Task AddAsync(Movie model);

        Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId);

        Task<Movie> GetByIdMovieAsync(int movieId);
    }
}
