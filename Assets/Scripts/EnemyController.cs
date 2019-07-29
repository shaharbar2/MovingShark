using UnityEngine;

namespace Boris.Game
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private float rotateSpeed = 5.0f;
        [SerializeField] private ScoreController scoreController;
        [SerializeField] private int scoreWorth = 10;
        [SerializeField] private float borderOffset = 20.0f;
        [SerializeField] private float wallOffset = 100.0f;

        private Quaternion targetRotation;
        private const double EPSILON_MOVEMENT = 0.05;

        void Update()
        {
            MovePlayerKeys();
            MovePlayerTouch();
        }
        
        private void MovePlayerKeys()
        {
            transform.position += 
                Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed +
                Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        }

        private void MovePlayerTouch()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log(other.gameObject.tag);
                scoreController.OnChangeScore(-1 * scoreWorth);
                ChangeLocation();

            }
            else if (other.CompareTag("Wall"))
            {
                ChangeLocation();
            }
        }

        private void ChangeLocation()
        {
            // new location on our world, the reason for Vector3 is, as  we are in the 3d world with the camera
            // z = 10, puts the coin in front of the camera
            var newSpawnPoint = new Vector3(
                Random.Range(0 + borderOffset, Screen.width - borderOffset),
                Random.Range(0 + borderOffset + wallOffset, Screen.height - borderOffset),
                10);

            transform.position = Camera.main.ScreenToWorldPoint(newSpawnPoint);
        }
    }
}