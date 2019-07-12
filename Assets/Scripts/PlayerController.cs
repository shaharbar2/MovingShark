using UnityEngine;

namespace Boris.Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10.0f;
        
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
            var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }
}







