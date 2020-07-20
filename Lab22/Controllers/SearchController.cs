using System.Collections.Generic;
using System.Linq;
using Lab22.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab22.Controllers
{
    public class SearchController : Controller
    {
        private SearchResult _listOfMovies;

        public SearchController()
        {
            _listOfMovies = new SearchResult
            {
                MovieList = new List<Movie>() {
                new Movie("Godzilla: King of the Monsters", MovieGenre.Action),
                new Movie("Avengers: Infinity War", MovieGenre.Action),
                new Movie("Jumper", MovieGenre.Action),
                new Movie("Sonic the Hedgehog", MovieGenre.Action),
                new Movie("Deadpool 2", MovieGenre.Comedy),
                new Movie("Men In Black: International", MovieGenre.Comedy),
                new Movie("Step Brothers", MovieGenre.Comedy),
                new Movie("Bruce Almighty", MovieGenre.Comedy),
                new Movie("A Star is Born", MovieGenre.Drama),
                new Movie("Bohemian Rhapsody", MovieGenre.Drama),
                new Movie("Joker", MovieGenre.Drama),
                new Movie("It Chapter 2", MovieGenre.Horror),
                new Movie("Slender Man", MovieGenre.Horror),
                new Movie("A Quiet Place", MovieGenre.Horror),
                new Movie("Jigsaw", MovieGenre.Horror),
            }
            };

            _listOfMovies.MovieList= _listOfMovies.MovieList.OrderBy(x => x.Title).ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchResultTitle(string title)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _listOfMovies.SearchTitle(title);

            return View(_listOfMovies);
        }

        [HttpPost]
        public IActionResult SearchResultGenre(string genre)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _listOfMovies.SearchGenre(genre);

            return View(_listOfMovies);
        }

    }
}
