using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography;

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
                Destroy(this);
            }

            instance = this;

            //DontDestroyOnLoad(this);
        }
    }
}