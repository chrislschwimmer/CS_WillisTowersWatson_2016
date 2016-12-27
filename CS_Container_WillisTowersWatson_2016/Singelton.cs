namespace CS_Container_WillisTowersWatson_2016
{
    public class SingletonLifecycle : ILifecycle
    {
        private readonly IObjectCache _cache = new ObjectCache();

        public IObjectCache FindCache()
        {
            return _cache;
        }
    }
}
