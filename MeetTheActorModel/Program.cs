using Akka.Actor;
using Akka.Event;
using System;

namespace MeetTheActorModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // make an actor system 
            var actorModelSystem = ActorSystem.Create("MeetTheActorModel");
            Console.WriteLine($"{nameof(ActorSystem)}: Welcome!");

            // create top-level actors within the actor system
            Props projectionistProps = Props.Create<Projectionist>();
            IActorRef projectionistActor = actorModelSystem.ActorOf(projectionistProps, nameof(Projectionist));


            projectionistActor.Tell(new Rest());
            projectionistActor.Tell(new Operate());
            projectionistActor.Tell(new Operate());
            projectionistActor.Tell(new Rest());

            Console.ReadKey();

            actorModelSystem.RegisterOnTermination(()=>
            {
                Console.WriteLine($"{nameof(ActorSystem)}: I'm terminated!");
            });

            actorModelSystem.Terminate();

            // blocks the main thread from exiting until the actor system is shut down
            actorModelSystem.WhenTerminated.Wait();

            Console.WriteLine("Please press any key to terminate.");
            Console.ReadKey();
        }
    }
}
