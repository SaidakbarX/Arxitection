using DataAccess.Entity;

namespace Repository.Servis;

public interface IMovieRepository
{
    Guid WriteMovie(Movie movie);
    void DeleteMovie(Guid id);
    void UpdateMovie (Movie movie);
    Movie GetMovieById(Guid id);
    List<Movie> GetAllMovies();
}