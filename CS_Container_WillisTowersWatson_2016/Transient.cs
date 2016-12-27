namespace CS_Container_WillisTowersWatson_2016
{
    class TransientLifecycle : ILifecycle
    {
        public IObjectCache FindCache()
        {
            return new NullObjectCache();
        }
    }
}
