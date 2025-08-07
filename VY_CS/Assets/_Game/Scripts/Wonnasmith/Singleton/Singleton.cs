namespace Wonnasmith.Singleton
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance;

        /// <summary> Gets the instance </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }

        // Optional: Protected constructor to prevent external instantiation
        protected Singleton() { }
    }
}
