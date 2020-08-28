using CoreDemo.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Services
{
    public class MovieMemoryService : IMovieService
    {
        private readonly List<Movie> _movies = new List<Movie>();

        public MovieMemoryService()
        {
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 1,
                Name = "Superman",
                ReleaseDate = DateTime.Now.AddHours(3),
                Starring = "Nick"
            });
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 2,
                Name = "Ghost",
                ReleaseDate = DateTime.Now.AddHours(2),
                Starring = "Michael Jackson"
            });
            _movies.Add(new Movie
            {
                CinemaId = 2,
                Id = 3,
                Name = "Feu",
                ReleaseDate = DateTime.Now.AddHours(1),
                Starring = "Michael Jackson"
            });
        }

        public Task AddAsync(Movie model)
        {
            var maxId = _movies.Max(x => x.Id);
            model.Id = maxId;
            _movies.Add(model);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            return Task.Run(() => _movies.Where(x => x.CinemaId == cinemaId));
        }

        public Task<Movie> GetByIdMovieAsync(int movieId)
        {
            return Task.Run(() => _movies.FirstOrDefault(x => x.Id == movieId));
        }
    }
}
