using UnityEngine;

namespace Boris.Game
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public PoolManager pool;
        public AdsManager Ads;
        
        void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
            }

            instance = this;
            //DontDestroyOnLoad(this);
        }
    }
}