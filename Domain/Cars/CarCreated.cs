using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events;

namespace Domain.Cars
{
    public class CarCreated : DomainEvent
    {
        public Car Car { get; set; }

        public CarCreated(Car car)
        {
            this.Car = car;
        }
    }
}
