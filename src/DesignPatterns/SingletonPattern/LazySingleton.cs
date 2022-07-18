using System;

namespace SingletonPattern
{
    public class LazySingleton<T>
         where T : new() // wymusza, że typ T posiada konstruktor bezparametryczny (constraint)
    {
        private static Lazy<T> _instance = new Lazy<T>(() => new T());
        public static T Instance => _instance.Value;
    }
}
