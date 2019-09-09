using System;
using System.Collections.Generic;
using System.Text;

namespace DemoIoC
{
    public class MultipleConstructorsException : Exception
    {
        public MultipleConstructorsException(Type serviceType) : base("service " + serviceType.ToString() + " should have only one public constructor")
        { }
    }
   
}
