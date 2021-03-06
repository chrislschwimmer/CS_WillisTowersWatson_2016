﻿using System;
using System.Collections.Concurrent;

namespace CS_Container_WillisTowersWatson_2016
{
    [Serializable]
    internal class ObjectCache : IObjectCache
    {
        private readonly ConcurrentDictionary<object, object> _objects = new ConcurrentDictionary<object, object>();

        public int Count
        {
            get { return _objects.Count; }
        }

        //get cached key
        public object Get(object key)
        {
            var hasInstance = Has(key);
            return hasInstance ? _objects[key] : null;
        }

        public void Set(object key, object instance)
        {
            if (instance == null) return;

            if (Has(key))
            {
                var message = string.Format("An instance for key {0} is already in the cache.", key);
                throw new ArgumentException(message, "key");
            }

            _objects[key] = instance;
        }

        public void Clear()
        {
            foreach(var obj in _objects)
            {
                TryDispose(obj);
            }
            _objects.Clear();
        }

        private static void TryDispose(object cachedObject)
        {
            var disposable = cachedObject as IDisposable;
            if (disposable != null) disposable.Dispose();
        }

        //does the cache contain key
        private bool Has(object key)
        {
            var containsKey = _objects.ContainsKey(key);
            return containsKey;
        }
    }
}
