using Akka.Actor;
using System;

namespace MeetTheActorModel
{
    public class ConsoleWriterActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Console.WriteLine(message);
        }
    }
}