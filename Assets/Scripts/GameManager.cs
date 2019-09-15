using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boris.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public PoolManager pool;
        public AdsManager ads;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
            }

            instance = this;
            
            ads = new GameObject("AdsManager", typeof(AdsManager)).GetComponent<AdsManager>();
            ads.gameObject.transform.SetParent(this.transform);
            
            DontDestroyOnLoad(this);
        }

        public void LoadGame()
        {
            pool = new GameObject("PoolManager", typeof(PoolManager)).GetComponent<PoolManager>();
            DontDestroyOnLoad(pool);
            
            SceneManager.LoadScene(1);
        }

        public void EndGame()
        {
            Destroy(pool.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}