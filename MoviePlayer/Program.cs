using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
using MoviePlayer.Messages;
using MoviePlayer.Service;
using System;

namespace MoviePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            // create and build the container by registering types.
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterType<MoviePlayerService>().As<IMoviePlayerService>();
            builder.RegisterType<MoviePlayerActor>().AsSelf();
            var container = builder.Build();

            // create actor system 
            ActorSystem moviePlayerSystem = ActorSystem.Create("movie-player");
            var propsResolver = new AutoFacDependencyResolver(container, moviePlayerSystem);

            // create actor reference
            IActorRef moviePlayerActor = moviePlayerSystem.ActorOf(moviePlayerSystem.DI().Props<MoviePlayerActor>(), "MoviePlayerActor");
            moviePlayerActor.Tell(new PlayMovieMessage("Silent"));
            moviePlayerActor.Tell(new PlayMovieMessage("Silent"));
            moviePlayerActor.Tell(new StopPlayingMessage());

            // wait for input and terminate
            Console.Read();
            moviePlayerSystem.Terminate().Wait();
        }
    }
}
