using System;
using System.Collections.Generic;
using System.Text;

namespace DemoIoC
{
    public class UnregisteredServiceTypeException : Exception
    {
        public UnregisteredServiceTypeException(Type serviceType) : base("service " + serviceType.ToString() + " has not been registered")
        { }
    }
}
