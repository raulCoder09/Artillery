using System.Collections.Generic;
using _Scripts.Ui.Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class Cannon : MonoBehaviour
    {
        public CanonControls canonControls;
        private InputAction _aim;
        private InputAction _modifyPower;
        private InputAction _shoot;
        public static bool blockShoot;
    
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject bulletSpecial;
        [SerializeField] private GameObject gunFlash;
        [SerializeField] private GameObject burst;

        [SerializeField] private GameObject burstSound;
        private AudioSource _burstAudioSource;
        [SerializeField] private GameObject shootCannonSound;
        private AudioSource _shootCannonAudioSource;
    
        private GameObject _temp;
        private List<GameObject> _bullets= new List<GameObject>();
        private GameObject _shooter;
        private float _rotation;
        private void Awake()
        {
            canonControls = new CanonControls();
        }
        private void OnEnable()
        {
            _aim = canonControls.Cannon.Aim;
            _aim.Enable();
            _modifyPower = canonControls.Cannon.ModifyPower;
            _modifyPower.Enable();
            _shoot=canonControls.Cannon.Shoot;
            _shoot.Enable();
            _shoot.performed += Shooting;

        }
        private void Start()
        {
            _shooter = transform.Find("Shooter").gameObject;
            _shootCannonAudioSource = shootCannonSound.GetComponent<AudioSource>();
            _burstAudioSource = burstSound.GetComponent<AudioSource>();
        }
        private void Update()
        {
            if (Game._uiActive)
            {
                _rotation += _aim.ReadValue<float>()*GameManager.speedRotation;
                if (_rotation is <= 90 and >= 0)
                {
                    transform.eulerAngles = new Vector3(_rotation, 90, 0.0f);
                }
                if (_rotation > 90) _rotation = 90;
                if (_rotation < 0) _rotation = 0;
        
                CheckBulletsOutRange();
            }

        }
        private void Shooting(InputAction.CallbackContext context)
        {
            if (Game._uiActive)
            {
                if (!blockShoot)
                {
                    if (GameManager.ShootsByGame <= 0) return;
                    _shootCannonAudioSource.Play();
                    GameManager.ShootsByGame--;
                    _temp = Instantiate(GameManager.ShootsByGame<2 ? bulletSpecial : bullet, _shooter.transform.position, transform.rotation);
                    _bullets.Add(_temp);
                    var tempRb = _temp.GetComponent<Rigidbody>();
                    FollowCamera.target = _temp;
                    var shooterDirection = transform.rotation.eulerAngles;
                    shooterDirection.y = 90 - shooterDirection.x;
                    var gunFlashDirection = new Vector3(-90 + shooterDirection.x, 90, 0);
                    Instantiate(gunFlash, _shooter.transform.position, Quaternion.Euler(gunFlashDirection));
                    tempRb.linearVelocity = shooterDirection.normalized * GameManager.SpeedBall;
                    blockShoot = true;
                }
            }
            
        }

        private void CheckBulletsOutRange()
        {
            for (int i = _bullets.Count - 1; i >= 0; i--)
            {
                if (_bullets[i] != null && _bullets[i].transform.position.y < -20)
                {
                    _burstAudioSource.Play();
                    Instantiate(burst, _temp.transform.position, transform.rotation);
                    Destroy(_bullets[i]);
                    _bullets.RemoveAt(i);
                }
            }
        }
    }
}
