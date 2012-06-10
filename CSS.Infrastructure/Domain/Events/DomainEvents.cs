using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSS.Infrastructure.Infrastructure.Domain.Events
{
    public static class DomainEvents
    {
        public static IDomainEventHandlerFactory DomainEventHandlerFactory { get; set; }

        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            DomainEventHandlerFactory.GetDomainEventHandlersFor(domainEvent).ForEach(h => h.Handle(domainEvent));
        }
    }
}
