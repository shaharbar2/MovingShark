using UnityEngine;
using UnityEngine.Advertisements;

namespace Boris.Game
{
    public class MenuManager : MonoBehaviour
    {
        public void OnStartButtonClick()
        {
            GameManager.instance.LoadGame();
        }
    }
}