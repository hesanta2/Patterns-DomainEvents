using Domain.Cars;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    internal class CarDomainEventHandler : IDomainHandler, IDomainHandler<CarCreated>, IDomainHandler<CarStringified>
    {
        public void Handle(CarStringified domainEvent)
        {
            Console.WriteLine($"[{domainEvent.Created}] Car '<<{domainEvent.Car.CarType.Name}>>' is stringified!");
        }

        public void Handle(CarCreated domainEvent)
        {
            Console.WriteLine($"[{domainEvent.Created}] Car '<<{domainEvent.Car}>>' is created!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DomainEvents.Register(new CarDomainEventHandler());

            Car car = new Car(2, CarClass.Sport, "Audi R8", 335, 2);
        }
    }
}
