using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Task06_01
{
    public class Cache : IDisposable
    {
        private readonly Dictionary<string, Model> _dictionary = new();
        private readonly Timer _timer;
        private readonly int Size;

        public Cache(int size)
        {
            Size = size > 0 ? size : throw new ArgumentException("Must be non-negative");
            var tm = new TimerCallback(AutoRemove);

             _timer = new(tm, null, 0, 1000);
        }

        public void Set(string key, object obj)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            obj = obj ?? throw new ArgumentNullException(nameof(obj));

            if (_dictionary.Count < Size)
            {
                _dictionary[key] = new(obj, DateTime.Now);
            }

            else if (_dictionary.Count == Size)
            {
                var oldKey = _dictionary
                    .Aggregate((x, y) => x.Value.Date < y.Value.Date ? x : y)
                    .Key;
                _dictionary.Remove(oldKey);
                _dictionary[key] = new(obj, DateTime.Now);
            }
        }

        public object Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (_dictionary.TryGetValue(key, out Model cache))
            {
                cache.Date = DateTime.Now;
                return cache.Obj;
            }

            return null;
        }

        public bool Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (_dictionary.ContainsKey(key))
            {
                _dictionary.Remove(key);

                return true;
            }

            return false;
        }

        private void AutoRemove(object obj)
        {
            var oldElements = _dictionary.Where(x => x.Value.Date.AddSeconds(10) < DateTime.Now).ToList();

            if (oldElements.Count > 0)
            {
                foreach (var item in oldElements)
                {
                    _dictionary.Remove(item.Key);
                }
            }
        }

        public void Dispose() => _timer.Dispose();

        private class Model
        {
            public object Obj { get;}

            public DateTime Date { get; set; }
            public Model(object obj, DateTime date  )
            {
                Obj = obj;
                Date = date;
            }
        }
    }
}
