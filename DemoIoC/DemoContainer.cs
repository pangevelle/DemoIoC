using System;
using System.Collections.Generic;
using System.Reflection;

namespace DemoIoC
{
    public class DemoContainer
    {
        private readonly Dictionary<Type, Type> registeredTypes = new Dictionary<Type, Type>();

        /// <summary>
        /// registration method 
        /// </summary>
        /// <param name="serviceType">Type of the interface to resolve</param>
        /// <param name="implementationType">Type of the implentation for the interface </param>
        public void Register(Type serviceType, Type implementationType)
        {
            registeredTypes.Add(serviceType, implementationType);
        }

        /// <summary>
        /// Resolution of an interface
        /// </summary>
        /// <param name="serviceType">Type of the interface to resolve</param>
        /// <returns>Implementation of the interface with injected dependencies</returns>
        public object Resolve(Type serviceType)
        {
            if (!registeredTypes.ContainsKey(serviceType))
                throw new UnregisteredServiceTypeException(serviceType);
            
            Type implementation = registeredTypes[serviceType];

            // find implementation's constructor's parameters    
            var implentationCtors = implementation.GetConstructors();

            if (implentationCtors.Length != 1)
                throw new MultipleConstructorsException(serviceType);

            ConstructorInfo implentationCtor = implentationCtors[0];
            var ctorParams = implentationCtor.GetParameters();

            // resolve implementation's constructor's parameters
            var ctorParamsImplentation = new List<object>();
            foreach (var ctorParam in ctorParams)
            {
                ctorParamsImplentation.Add(Resolve(ctorParam.ParameterType));
            }

            // Create implementation instance with injection of resolved parameters
            return Activator.CreateInstance(implementation, ctorParamsImplentation.ToArray());
        }
    }
}
