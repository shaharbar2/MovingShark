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

            DontDestroyOnLoad(this);
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(1);
        }

        public void EndGame()
        {
            pool.ResetPools();
            SceneManager.LoadScene(0);
        }
    }
}