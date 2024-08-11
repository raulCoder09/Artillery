using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private GameObject burstParticle;
        private static int _life;
        internal static int Life
        {
            get => _life;
            set => _life = value;
        }
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Burst"))
            {
                _life--;
                
            }else if (collision.CompareTag("SpecialBurst"))
            {
                _life -= 3;
            }
            if (_life<=0)
            {
                Destroy(gameObject);
            }
        }
        private void Update()
        {
            CheckTargetOutRange();
        }

        private void CheckTargetOutRange()
        {
            if (gameObject.transform.position.y < -25)
            {
                _life = 0;
                Instantiate(burstParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
