using UnityEngine;

namespace _Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject burstParticle;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                Invoke(nameof(Burst),3f);
            }
            if (collision.gameObject.CompareTag("Target") || collision.gameObject.CompareTag("Obstacle")) Burst();
        }
        private void Burst()
        {
            var particles = Instantiate(burstParticle, transform.position, Quaternion.identity) as GameObject;
            Cannon.blockShoot = false;
            FollowCamera.target = null;
            Destroy(gameObject);
        }
    }
}
