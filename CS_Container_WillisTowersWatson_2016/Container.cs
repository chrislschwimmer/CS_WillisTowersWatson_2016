using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_Container_WillisTowersWatson_2016
{
    public class Container
    {
        private readonly IList<RegisteredObject> _registeredObjects = new List<RegisteredObject>();

        public void Register<T1, T2>(Lifecycle lifecycle = Lifecycle.Transient)
        {
            _registeredObjects.Add(new RegisteredObject(typeof(T1), typeof(T2), lifecycle));
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type typeToResolve)
        {
            var registeredObject = _registeredObjects.FirstOrDefault(o => o.TypeToResolveFrom == typeToResolve);
            if (registeredObject == null)
                throw new Exception(String.Format("The type {0} has not been registered", typeToResolve.Name));

            return GetInstance(registeredObject);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            //try to find the instance in cache
            var lifecycleCache = registeredObject.Lifecycle.Get().FindCache();
            var instance = lifecycleCache.Get(registeredObject.InstanceKey);

            if (instance == null)
            {
                //not found in cache so create new instance
                instance = ResolveObject(registeredObject.TypeToResolveFrom);

                //add to cache depending on the lifecycle type
                lifecycleCache.Set(registeredObject.InstanceKey, instance);
            }

            return instance;
        }

        private object ResolveObject(Type typeToResolve)
        {
            Type resolvedType = null;

            var registeredObject = _registeredObjects.Where(w => w.TypeToResolveFrom == typeToResolve).FirstOrDefault();

            if (registeredObject == null)
            {
                throw new Exception(string.Format("type {0} not found in registered objects collection", typeToResolve.FullName));
            }

            resolvedType = registeredObject.TypeToResolveTo;

            var firstConstructor = resolvedType.GetConstructors().FirstOrDefault();

            if(firstConstructor == null)
            {
                throw new Exception(string.Format("unable to resolve contructor for type {0}", typeToResolve.FullName));
            }

            var constructorParamater = firstConstructor.GetParameters();
            if (constructorParamater.Count() == 0)
            {
                //no parameters so create instance
                return Activator.CreateInstance(resolvedType);
            }

            IList<object> parameters = new List<object>();

            //problem only the first parameter not found will be in the exception
            foreach (var parameterToResolve in constructorParamater)
            {
                parameters.Add(ResolveObject(parameterToResolve.ParameterType));
            }

            return firstConstructor.Invoke(parameters.ToArray());
        }
    }
}
