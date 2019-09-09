using DemoIoC;
using System;
using Xunit;

namespace DemoIoc.test
{
    public class ResolverTests
    {
        [Fact]
        public void ResolveSingleObject()
        {
            DemoContainer demoContainer = new DemoContainer();
            demoContainer.Register(typeof(IHello), typeof(Hello));

            var impl = demoContainer.Resolve(typeof(IHello));

            Assert.IsType<Hello>(impl);
        }

        [Fact]
        public void ResolveObjectWithDependency()
        {
            DemoContainer demoContainer = new DemoContainer();
            demoContainer.Register(typeof(IHello), typeof(Hello2));
            demoContainer.Register(typeof(ISomething), typeof(Something));

            var impl = demoContainer.Resolve(typeof(IHello));

            Assert.IsType<Hello2>(impl);
            Assert.Equal("Hello, I did something", ((Hello2)impl).SayHello());
        }
    }
}
