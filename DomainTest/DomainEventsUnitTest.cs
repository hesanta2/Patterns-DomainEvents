using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Events;
using Domain.Cars;
using Rhino.Mocks;

namespace DomainTest
{
    [TestClass]
    public class DomainEventsUnitTest
    {

        [TestMethod]
        public void DomainEvent_New_Is_Not_Null()
        {
            DomainEventForTest domainEvent = new DomainEventForTest();

            Assert.IsNotNull(domainEvent);
            Assert.IsTrue(domainEvent.Created != DateTime.MinValue);
        }

        [TestMethod]
        public void DomainEvents_Raise_DomainEvent_With_Action()
        {
            bool domainEventRaised = false;
            DomainEvents.Register<DomainEventForTest>(domainEvent => domainEventRaised = true);
            DomainEvents.Raise(new DomainEventForTest());

            Assert.IsTrue(domainEventRaised);
        }

        [TestMethod]
        public void DomainEvents_Raise_DomainEvent_With_DomainHandler()
        {
            DomainHandlerForTest domainHandler = new DomainHandlerForTest();

            DomainEvents.Register(domainHandler);
            DomainEvents.Raise(new DomainEventForTest());
            DomainEvents.ClearCallbacks();

            Assert.IsTrue(domainHandler.HandleIsCalled);
        }

        public class DomainEventForTest : DomainEvent { }
        public class DomainHandlerForTest : IDomainHandler, IDomainHandler<DomainEventForTest>
        {
            public bool HandleIsCalled { get; set; }
            public void Handle(DomainEventForTest domainEvent)
            {
                this.HandleIsCalled = true;
            }
        }

    }
}
