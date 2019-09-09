using System;
using System.Collections.Generic;
using System.Text;

namespace DemoIoc.test
{
    public interface IHello
    {
        string SayHello();
    }

    public interface ISomething
    {
        string DoSomething();
    }

    public class Hello : IHello
    {
        public string SayHello()
        {
            return "Hello";
        }
    }

    public class Hello2 : IHello
    {
        readonly ISomething something;
        public Hello2(ISomething something)
        {
            this.something = something;
        }

        public string SayHello()
        {
            var someResult =  something.DoSomething();
            return "Hello, " + someResult;
        }
    }

    public class Something : ISomething
    {
        public string DoSomething()
        {
            return "I did something";
        }
    }
}
