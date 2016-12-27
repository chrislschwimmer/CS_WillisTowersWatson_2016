using System;

namespace CS_Container_WillisTowersWatson_2016
{
    public class RegisteredObject
    {
        public RegisteredObject(Type typeToResolveFrom, Type typeToResolveTo, Lifecycle lifecycle)
        {
            TypeToResolveFrom = typeToResolveFrom;
            TypeToResolveTo = typeToResolveTo;
            InstanceKey = Guid.NewGuid();
            Lifecycle = lifecycle;
        }

        public Type TypeToResolveFrom { get; private set; }
        public Type TypeToResolveTo { get; private set; }
        public Guid InstanceKey { get; private set; }
        public Lifecycle Lifecycle { get; private set; }
    }
}
