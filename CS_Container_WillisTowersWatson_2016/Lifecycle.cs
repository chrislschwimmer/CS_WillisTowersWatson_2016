namespace CS_Container_WillisTowersWatson_2016
{
    public enum Lifecycle
    {
        Transient,
        Singleton
    }

    public static class Lifecycle<T> where T : ILifecycle, new()
    {
        static Lifecycle()
        {
            Instance = new T();
        }

        public static ILifecycle Instance { get; private set; }
    }

}
