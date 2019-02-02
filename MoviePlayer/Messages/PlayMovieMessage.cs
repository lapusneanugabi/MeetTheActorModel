namespace MoviePlayer.Messages
{
    public class PlayMovieMessage
    {
        public PlayMovieMessage(string movieName)
        {
            MovieName = movieName;
        }

        public string MovieName { get; private set; }
    }
}
