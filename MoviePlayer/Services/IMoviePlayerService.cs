using MoviePlayer.Models;

namespace MoviePlayer.Service
{
    public interface IMoviePlayerService
    {
        Movie GetMovieByName(string movieName);
    }
}
