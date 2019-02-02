using System;
using Akka.Actor;
using MoviePlayer.Messages;
using MoviePlayer.Models;

namespace MoviePlayer.Service
{
    public class MoviePlayerActor : ReceiveActor
    {
        protected Movie CurrentMovie;
        public IMoviePlayerService MoviePlayerService { get; private set; }

        public MoviePlayerActor(IMoviePlayerService moviePlayerService)
        {
            MoviePlayerService = moviePlayerService;
            StoppedBehavior();
        }

        private void StoppedBehavior()
        {
            Receive<PlayMovieMessage>(m => HandlePlayMovie(m.MovieName));
            Receive<StopPlayingMessage>(m =>
                           Console.WriteLine("Cannot stop, the actor is already stopped"));
        }

        private void PlayingBehavior()
        {
            Receive<PlayMovieMessage>(m =>
               Console.WriteLine($"Cannot play. Currently playing '{CurrentMovie.Name}'."));
            Receive<StopPlayingMessage>(m => HandleStopPlaying());
        }

        private void HandlePlayMovie(string movieName)
        {
            CurrentMovie = MoviePlayerService.GetMovieByName(movieName);
            Console.WriteLine($"Currently playing '{CurrentMovie.Name}'.");

            Become(PlayingBehavior);
        }

        private void HandleStopPlaying()
        {
            CurrentMovie = null;
            Console.WriteLine($"Player is currently stopped.");

            Become(StoppedBehavior);
        }
    }
}
