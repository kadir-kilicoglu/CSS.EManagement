using System;

namespace CSS.Infrastructure.Domain
{
    public class ValueObjectIsInvaliException : Exception
    {
        public ValueObjectIsInvaliException(string message)
            : base(message)
        {
        }
    }
}
