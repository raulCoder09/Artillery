using System.Collections;
using UnityEngine;
public class BulletSpecial : MonoBehaviour
{
    [SerializeField] private GameObject burst;
    private bool _burstDone;

    private void Update()
    {
        var sleeping = GetComponent<Rigidbody>().IsSleeping();
        if (sleeping&&!_burstDone)
        {
            Instantiate(burst, transform.position, transform.rotation);
            _burstDone = true;
           StartCoroutine(nameof(WaitToDestroy));
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
