using Akka.Actor;
using System;

namespace MeetTheActorModel
{
    public class Projectionist : ReceiveActor
    {
        public Projectionist()
        {
            Console.WriteLine(Common.MessageTemplate, nameof(Projectionist), "Hello! I'm new here!");
            Become(SleepingBehavior);
        }

        private void SleepingBehavior()
        {
            Receive<Operate>(message => {
                OperateHandler(message);
            });

            Receive<Rest>(message => {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(Common.FromTemplate, $"{Context.Sender}");
                Console.WriteLine(Common.ActionTemplate, $"{nameof(Rest)}");
                Console.WriteLine();
                Console.WriteLine(Common.MessageTemplate, nameof(Projectionist), "I am already sleeping, I'm not operating any projector.");
                Console.WriteLine("--------------------------------------");
            });

            Receive<string>(message =>
            {
                Console.WriteLine($"{nameof(Projectionist)}: {0}", message);
            });
        }

        private void OperatingBehavior()
        {
            Receive<Operate>(message => {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(Common.FromTemplate, $"{Context.Sender}");
                Console.WriteLine(Common.ActionTemplate, $"{nameof(Operate)}");
                Console.WriteLine();
                Console.WriteLine(Common.MessageTemplate, nameof(Projectionist), "I can operate only one projector at the same time.");
                Console.WriteLine("--------------------------------------");
            });

            Receive<Rest>(message => {
                RestHandler(message);
            });
        }

        private void RestHandler(Rest message)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(Common.FromTemplate, $"{Context.Sender}");
            Console.WriteLine(Common.ActionTemplate, $"{nameof(Rest)}");
            Console.WriteLine();
            Console.WriteLine(Common.MessageTemplate, nameof(Projectionist), "I'm resting.");
            Console.WriteLine("--------------------------------------");
        }

        private void OperateHandler(Operate obj)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(Common.FromTemplate, $"{Context.Sender}");
            Console.WriteLine(Common.ActionTemplate, $"{nameof(Operate)}");
            Console.WriteLine();
            Console.WriteLine(Common.MessageTemplate, nameof(Projectionist), "I'm operating a projector.");
            Console.WriteLine("--------------------------------------");

            Become(OperatingBehavior);
        }
    }
}
