using System;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public static bool blockShoot;
    [SerializeField] private GameObject bullet;
    private GameObject _shooter;
    private float _rotation;
    private void Start()
    {
        _shooter = transform.Find("Shooter").gameObject;
    }
    private void Update()
    {
        _rotation += Input.GetAxis("Horizontal")*GameManager.speedRotation;
        if (_rotation is <= 90 and >= 0)
        {
            transform.eulerAngles = new Vector3(_rotation, 90, 0.0f);
        }
        if (_rotation > 90) _rotation = 90;
        if (_rotation < 0) _rotation = 0;
        if (Input.GetKey(KeyCode.Space) && !blockShoot)
        {
            
            var temp = Instantiate(bullet, _shooter.transform.position, transform.rotation);
            var tempRb = temp.GetComponent<Rigidbody>();
            FollowCamera.target = temp;
            var shooterDirection = transform.rotation.eulerAngles;
            shooterDirection.y = 90 - shooterDirection.x;
            tempRb.linearVelocity = shooterDirection.normalized * GameManager.speedBall;
            blockShoot = true;
        }
        
    }
    
}
