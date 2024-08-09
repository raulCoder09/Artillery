using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class Target : MonoBehaviour
    {
        [SerializeField]private int life = 10;
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Burst"))
            {
                life--;
                
            }else if (collision.CompareTag("SpecialBurst"))
            {
                life -= 3;
            }
            if (life<=0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
