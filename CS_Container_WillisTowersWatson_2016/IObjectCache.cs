namespace CS_Container_WillisTowersWatson_2016
{
    public interface IObjectCache
    {
        object Get(object key);
        void Set(object key, object instance);
        void Clear();
    }
}
