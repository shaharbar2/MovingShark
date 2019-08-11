using UnityEngine;

namespace Boris.Game
{
    public class CollectibleController : MonoBehaviour
    {
        [SerializeField] private int scoreWorth = 10;
        [SerializeField] private float borderOffset = 20.0f;
        [SerializeField] private ScoreController scoreController;
        [SerializeField] private ParticleSystem coinParticle;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log(other.gameObject.tag);
                scoreController.OnChangeScore(scoreWorth);
                ChangeLocation();

            }
            else if (other.CompareTag("Wall"))
            {
                ChangeLocation();
            }
        }

        private void ChangeLocation()
        {
            coinParticle.transform.position = transform.position;
            coinParticle.Play();

           // new location on our world, the reason for Vector3 is, as  we are in the 3d world with the camera
            // z = 10, puts the coin in front of the camera
            var newSpawnPoint = new Vector3(
                Random.Range(0 + borderOffset, Screen.width - borderOffset),
                Random.Range(0 + borderOffset, Screen.height - borderOffset),
                10);

            transform.position = Camera.main.ScreenToWorldPoint(newSpawnPoint);
        }
    }
}