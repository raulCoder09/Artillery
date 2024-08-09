using System.Collections;
using UnityEngine;
public class BulletSpecial : MonoBehaviour
{
    [SerializeField] private GameObject burst;
    private bool _burstDone;
    private GameObject _burstSound;
    private AudioSource _burstAudioSource;
    private void Start()
    {
        _burstSound=GameObject.Find("BurstSound");
        _burstAudioSource = _burstSound.GetComponent<AudioSource>();
    }

    private void Update()
    {
        var sleeping = GetComponent<Rigidbody>().IsSleeping();
        if (sleeping&&!_burstDone)
        {
            Instantiate(burst, transform.position, transform.rotation);
            _burstDone = true;
           StartCoroutine(nameof(WaitToDestroy));
           _burstAudioSource.Play();
           Destroy(gameObject);
        }
        else
        {
            StopCoroutine(nameof(WaitToDestroy));
        }
    }

    private IEnumerator WaitToDestroy()
    {
        yield return new WaitForSecondsRealtime(3f);
    }
}
