using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public static bool blockShoot;
    
    [SerializeField] private GameObject bullet;
    private List<GameObject> _bullets= new List<GameObject>();
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
        if (GameManager.ShootsByGame>0)
        {
            if (Input.GetKey(KeyCode.Space) && !blockShoot)
            {
                GameManager.ShootsByGame--;
                var temp = Instantiate(bullet, _shooter.transform.position, transform.rotation);
                _bullets.Add(temp);
                var tempRb = temp.GetComponent<Rigidbody>();
                FollowCamera.target = temp;
                var shooterDirection = transform.rotation.eulerAngles;
                shooterDirection.y = 90 - shooterDirection.x;
                tempRb.linearVelocity = shooterDirection.normalized * GameManager.SpeedBall;
                blockShoot = true;
                print($"shots available: {GameManager.ShootsByGame}");
            }
        }
        else
        {
            print("You dont have more shoots");
        }
        CheckBulletsOutRange();
    }

    private void CheckBulletsOutRange()
    {
        for (int i = _bullets.Count - 1; i >= 0; i--)
        {
            if (_bullets[i] != null && _bullets[i].transform.position.y < -20)
            {
                Destroy(_bullets[i]);
                _bullets.RemoveAt(i);
            }
        }
    }
}
