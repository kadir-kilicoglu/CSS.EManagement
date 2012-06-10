using System;
using System.Collections.Generic;
//using StructureMap;

namespace CSS.Infrastructure.Infrastructure.Domain.Events
{
    public class StructureMapDomainEventHandlerFactory : IDomainEventHandlerFactory
    {
        public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent) where T : IDomainEvent
        {
            return null;//ObjectFactory.GetAllInstances<IDomainEventHandler<T>>();  
        }
    }
}
