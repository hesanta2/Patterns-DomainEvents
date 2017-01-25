using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Cars;
using Domain.Events;

namespace Domain.Test
{
    [TestClass]
    public class CarUnitTest
    {
        private Car car;

        [TestInitialize]
        public void Setup()
        {
            this.car = new Car(1, CarClass.Normal, "Car", 200, 5);
        }

        [TestMethod]
        public void CarAggregate_Id_Is_Not_Null()
        {
            Assert.IsNotNull(car.Id);
        }

        [TestMethod]
        public void CarAggregate_Is_Typeof_AggregateRoot()
        {
            Assert.IsInstanceOfType(car, typeof(IAggregateRoot));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarAggregate_Name_Is_Null_ThrowsException()
        {
            Car nullNameCar = new Car(1, CarClass.Normal, null, 240, 5);
        }
        [TestMethod]
        public void CarAggregate_New_Without_Id_Is_Not_Null()
        {
            Car newCar = new Car(CarClass.Normal, "Car", 240, 5);

            Assert.IsNotNull(newCar);
        }

        [TestMethod]
        public void CarAggregate_ToString_IsNotNull()
        {
            Assert.IsNotNull(car.ToString());
        }

        [TestMethod]
        public void CarCreated_New_IsNotNull()
        {
            CarCreated carDomainEvent = new CarCreated(this.car);
            Assert.IsNotNull(carDomainEvent);
            Assert.IsNotNull(carDomainEvent.Car);
        }

        [TestMethod]
        public void CarStringified_New_IsNotNull()
        {
            CarStringified carDomainEvent = new CarStringified(this.car);
            Assert.IsNotNull(carDomainEvent);
            Assert.IsNotNull(carDomainEvent.Car);
        }
    }
}
