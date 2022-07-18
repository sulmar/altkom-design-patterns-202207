using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    // Szablon singletona (klasa generyczna)
    public class Singleton<T>
         where T : new() // wymusza, że typ T posiada konstruktor bezparametryczny (constraint)
    {
        private static object sync = new object();

        private static T _instance;

        public static T Instance
        {
            get
            {
                lock (sync)
                {
                    if (_instance == null)
                    {
                        return new T();
                    }
                }

                return _instance;
            }
        }
    }
}
