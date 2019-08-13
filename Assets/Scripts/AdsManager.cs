using UnityEngine;
using UnityEngine.Advertisements;

namespace Boris.Game
{
    public class AdsManager : MonoBehaviour
    {
        public void ShowVideoAd()
        {
            Advertisement.Show();
        }
    }
}