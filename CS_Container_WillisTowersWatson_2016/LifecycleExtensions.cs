namespace CS_Container_WillisTowersWatson_2016
{
    public static class LifecycleExtensions
    {
        public static ILifecycle Get(this Lifecycle lifecycle)
        {
            switch (lifecycle)
            {
                case Lifecycle.Singleton:
                    return Lifecycle<SingletonLifecycle>.Instance;
                default: // Transient
                    return Lifecycle<TransientLifecycle>.Instance;
            }
        }
    }
}
