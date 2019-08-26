using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Boris.Game
{
    public class AdsManager : MonoBehaviour
    {
        private void Awake()
        {
            ShowVideoAd();
        }

        public void ShowVideoAd()
        {
            Advertisement.Show();
        }
    }
}