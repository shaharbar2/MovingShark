using UnityEngine;
using UnityEngine.UI;

namespace Boris.Game
{
    [RequireComponent(typeof(ParticleSystem ))]
    public class ParticleEndPlay : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particleSystem;

        private void Reset()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if (!particleSystem.isPlaying)
            {
               GameManager.instance.pool.ReturnPooledObject(this.gameObject);
            }
        }
    }
}