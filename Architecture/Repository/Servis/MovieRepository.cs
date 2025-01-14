using DataAccess.Entity;
using System.Text.Json;

namespace Repository.Servis;

public class MovieRepository : IMovieRepository
{
    private string _path;
    private List<Movie> _movies;
    public MovieRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Movie.json");
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _movies = GetAllMovies();
    }
    public void DeleteMovie(Guid id)
    {
        var delet = GetMovieById(id);
        _movies.Remove(delet);
        SaveData();
    }

    public List<Movie> GetAllMovies()
    {
        var movie = File.ReadAllText(_path);
        var movieJson = JsonSerializer.Deserialize<List<Movie>>(movie);
        return movieJson;
    }

    public Movie GetMovieById(Guid id)
    {
        var movie = _movies.FirstOrDefault(x => x.Id == id);
        if (movie == null)
        {
            throw new Exception("Errorrr");
        }
        return movie;
    }

    public void UpdateMovie(Movie movie)
    {
        _movies[_movies.IndexOf(movie)] = movie;
        SaveData();
    }

    public Guid WriteMovie(Movie movie)
    {
        _movies.Add(movie);
        movie.Id = Guid.NewGuid();
        SaveData();
        return movie.Id;
    }
    private void SaveData()
    {
        var movieJson = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, movieJson);
    }
}
