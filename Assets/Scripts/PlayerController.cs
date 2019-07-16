using UnityEngine;

namespace Boris.Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10.0f;
        [SerializeField] private float rotateSpeed = 10.0f;

        private Quaternion targetRotation;
        
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.gameObject.tag);
        }

        private void MovePlayerTouch()
        {

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // calculate the target angle
            var direction = new Vector3(touchPosition.x, touchPosition.y, 0) - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // interpolate rotate into the target angle
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            
            // progress toward to relative new direction
            transform.position += moveSpeed * Time.deltaTime * transform.right;
        }
    }
}







