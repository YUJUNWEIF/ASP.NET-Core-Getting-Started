using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Services;

namespace CoreDemo.ViewComponents
{
    /// <summary>
    /// 复用的ViewComponent
    /// </summary>
    public class MovieCountViewComponent : ViewComponent
    {
        private readonly IMovieService _movieService;

        public MovieCountViewComponent(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int cinemaId)
        {
            var movies = await _movieService.GetByCinemaAsync(cinemaId);
            var count = movies.Count();

            return View(count);
        }
    }
}
