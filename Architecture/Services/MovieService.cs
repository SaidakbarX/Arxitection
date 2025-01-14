using DataAccess.Entity;
using Repository.Servis;
using Services.Dto;

namespace Services;

public class MovieService : IMovieService
{
    private IMovieRepository _repository;
    public MovieService()
    {
        _repository = new MovieRepository();
    }
    public Guid AddMovie(MovieDto movie)
    {
        var movies = ConvertToEntity(movie);
        _repository.WriteMovie(movies);
        return movie.Id;
    }

    public void DeleteMovie(Guid id)
    {
        _repository.DeleteMovie(id);
    }

    public List<MovieDto> GetAllMovies()
    {
        var movie = _repository.GetAllMovies();
        var movis = movie.Select(mv => ConvertToDto(mv)).ToList();
        return movis;
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return GetAllMovies().Where(mv =>  mv.Director == director).ToList();   
    }

    public MovieDto GetHighestGrossingMovie()
    {
        var maxCash = GetAllMovies().Max(mv =>mv.BoxOfficeEarnings);
        return GetAllMovies().First(mv => mv.BoxOfficeEarnings == maxCash);
    }

    public MovieDto GetMovieById(Guid id)
    {
       var movie = _repository.GetMovieById(id);
        return ConvertToDto(movie);
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        return GetAllMovies().Where(mv => mv.ReleaseDate.Year > year).ToList();
        
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        return GetAllMovies().OrderBy(mv => mv.Rating).ToList();
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        return GetAllMovies().Where ( mv => mv.DurationMinutes > minMinutes &&  mv.DurationMinutes < maxMinutes).ToList();
    }

    public List<MovieDto> GetRecentMovies(int years)
    {
        return GetAllMovies().Where(mv => mv.ReleaseDate.Year == years).ToList();
    }

    public MovieDto GetTopRatedMovie()
    {
        var maxRating = GetAllMovies().Max(mv => mv.Rating);
        return GetAllMovies().First(mv => mv.Rating == maxRating);
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        return GetAllMovies().Where(mv => mv.Director == director).Sum(mv => mv.BoxOfficeEarnings);
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        return GetAllMovies().Where(mv => mv.Title.Contains( keyword)).ToList();
    }

    public void UpdateMovie(MovieDto movie)
    {
        var movies = ConvertToEntity(movie);
        _repository.UpdateMovie(movies);
    }
    private Movie ConvertToEntity (MovieDto movie)
    {
        return new Movie
        {
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Id = movie.Id,
            Rating = movie.Rating,
            ReleaseDate = movie.ReleaseDate,

        };
    }
    private MovieDto ConvertToDto (Movie movie)
    {
        return new MovieDto
        {
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            Id = movie.Id,
            DurationMinutes = movie.DurationMinutes,
            Director = movie.Director,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            Title = movie.Title,

        };
    }
}
