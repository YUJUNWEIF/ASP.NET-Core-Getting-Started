using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.models;
using CoreDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;

        /// <summary>
        ///  构造函数依赖注入
        /// </summary>
        /// <param name="movieService"></param>
        /// <param name="cinemaService"></param>
        public MovieController(IMovieService movieService, ICinemaService cinemaService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            ViewBag.Title = $"{cinema.Name}上映的电影有：";
            ViewBag.CinemaId = cinemaId;

            return View(await _movieService.GetByCinemaAsync(cinemaId));
        }

        public ActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie { CinemaId = cinemaId });
        }

        public async Task<IActionResult> Edit(int movieId)
        {
            var movie = await _movieService.GetByIdMovieAsync(movieId);
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Movie model)
        {
            if (ModelState.IsValid)
            {
                var exist = await _movieService.GetByIdMovieAsync(model.Id);
                if (exist == null)
                {
                    return NotFound();
                }

                exist.Name = model.Name;
                exist.CinemaId = model.CinemaId;
                exist.Starring = model.Starring;
                exist.ReleaseDate = model.ReleaseDate;
            }

            return RedirectToAction("Index", new { cinemaId = model.CinemaId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(movie);
            }
            return RedirectToAction("Index", new { cinemaId = movie.CinemaId });
        }
    }
}
