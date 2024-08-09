using System;
using UnityEngine;

namespace _Scripts
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            //revisar esta parte
            // if (collision.CompareTag("SpecialBullet"))
            // {
            //     Invoke(nameof(DestroyObstacle),5f);
            // }
            if (collision.CompareTag("Burst")||collision.CompareTag("SpecialBurst"))DestroyObstacle();
        }

        private void DestroyObstacle()
        {
            Destroy(gameObject);
        }
    }
}
