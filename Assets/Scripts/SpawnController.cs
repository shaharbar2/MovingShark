using UnityEngine;

namespace Boris.Game
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private float spawnTime = 5.0f;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private int scoreWorth = 10;
        [SerializeField] private float borderOffset = 20.0f;
        [SerializeField] private float wallOffset = 100.0f;


        private void Start()
        {
            InvokeRepeating(nameof(Spawn), 0, spawnTime);
        }

        private void Spawn()
        {
            // new location on our world, the reason for Vector3 is, as  we are in the 3d world with the camera
            // z = 10, puts the coin in front of the camera
            var newSpawnPoint = new Vector3(
                Random.Range(0 + borderOffset, Screen.width - borderOffset),
                Random.Range(0 + borderOffset + wallOffset, Screen.height - borderOffset),
                10);

            // create new game object in Unity
            EnemyController temp =
                Instantiate(enemyController, Camera.main.ScreenToWorldPoint(newSpawnPoint), Quaternion.identity);

            temp.Init(playerController);
        }
    }
}