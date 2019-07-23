using UnityEngine;
using UnityEngine.UI;

namespace Boris.Game
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        private int totalScore;

        public void OnChangeScore(int scoreAmount)
        {
            totalScore += scoreAmount;
            scoreText.text = totalScore.ToString();
        }
    }
}