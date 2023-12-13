using UnityEngine;

namespace F8Framework.Core
{
    public class SingletonMono<T> : MonoBehaviour where T : Component
    {
        private static T m_instace;
        private static readonly object lockObj = new object();

        public static T Instance
        {
            get
            {
                if (m_instace == null)
                {
                    lock (lockObj)
                    {
                        m_instace = FindObjectOfType<T>();
                        if (m_instace == null)
                        {
                            GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                            m_instace = obj.GetComponent<T>();
                            DontDestroyOnLoad(obj);
                        }
                    }
                }

                return m_instace;
            }
        }
        private void Awake()
        {
            Init();
        }
        protected virtual void Init()
        {

        }
        
        public virtual void OnEnterGame()
        {

        }

        public virtual void OnQuitGame()
        {

        }
        
        private void OnDestroy()
        {
            OnQuitGame();
            m_instace = null;
        }
    }
}