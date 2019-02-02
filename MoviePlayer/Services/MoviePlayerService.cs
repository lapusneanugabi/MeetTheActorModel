using MoviePlayer.Models;

namespace MoviePlayer.Service
{
    public class MoviePlayerService : IMoviePlayerService
    {
        public Movie GetMovieByName(string movieName)
        {
            return new Movie(movieName, new byte[0]);
        }
    }
}
