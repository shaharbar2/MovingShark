using UnityEngine;

namespace Boris.Game
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 0.3f;
        [SerializeField] private float rotateSpeed = 4.0f;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private GameObject explodeParticle;

        private Quaternion targetRotation;
        private const double EPSILON_MOVEMENT = 0.08;

        public void Init(PlayerController player)
        {
            playerController = player;
        }

        void Update()
        {
            MoveEnemy();
        }

        private void MoveEnemy()
        {
            // calculate direction vector
            Vector3 touchPosition = playerController.transform.position;
            var direction = new Vector3(touchPosition.x, touchPosition.y, 0) - transform.position;

            // check if the shark reached the target
            if (!(direction.magnitude > EPSILON_MOVEMENT)) return;

            // calculate the target angle
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // interpolate rotate into the target angle
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            // progress toward to relative new direction
            transform.position += moveSpeed * Time.deltaTime * transform.right;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("EnemyCollision"))
            {
                var explosion = GameManager.instance.pool.GetPooledObject(explodeParticle.name);
                explosion.transform.position = transform.position;
                explosion.SetActive(true);
                GameManager.instance.pool.ReturnPooledObject(this.gameObject);
            }
        }
    }
}