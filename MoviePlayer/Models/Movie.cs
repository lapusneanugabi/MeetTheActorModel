namespace MoviePlayer.Models
{
    public class Movie
    {
        public Movie(string name, byte[] rowFormat)
        {
            Name = name;
            RowFormat = rowFormat;
        }

        public string Name { get; private set; }
        public byte[] RowFormat { get; private set; }
    }
}