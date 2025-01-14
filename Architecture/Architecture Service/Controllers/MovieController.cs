using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;

namespace Architecture_Service.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        public MovieController()
        {
            _movieService = new MovieService();
        }
        [HttpPost("add movie")]
        public Guid AddMovie(MovieDto movie)
        {
            _movieService.AddMovie(movie);
            return movie.Id;
        }
        [HttpDelete("delet movie")]
        public void DeleteMovie(Guid id)
        {
            _movieService.DeleteMovie(id);
        }
        [HttpPut ("update movie")]
        public void UpdateMovie(MovieDto movie)
        {
            _movieService.UpdateMovie(movie);
        }
        [HttpGet ("get all movies")]
        public List<MovieDto> GetAllMovies()
        {
           return _movieService.GetAllMovies();

        }
        [HttpGet ("get by id book")]
        public MovieDto GetMovieById(Guid id)
        {
           return  _movieService.GetMovieById(id);
        }

        
    }
}
