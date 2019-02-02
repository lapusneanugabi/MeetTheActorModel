using Akka.Actor;
using System;

namespace MeetTheActorModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // create actor system 
            ActorSystem system = ActorSystem.Create("actor-system");

            // create top-level actors within the actor system
            Props consoleWriterProps = Props.Create<ConsoleWriterActor>();
            IActorRef consoleWriterActor = system.ActorOf(consoleWriterProps, "consoleWriterActor");

            // send the message async
            consoleWriterActor.Tell("> Hello Actor Model!");

            // wait for input and terminate
            Console.Read();
            system.Terminate().Wait();
        }
    }
}
