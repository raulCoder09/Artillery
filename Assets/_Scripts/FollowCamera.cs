using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public static GameObject target;

    [Header("Setting at editor")]
    public float smoothing = 0.05f;
    public Vector2 limitXY=Vector2.zero;

    [Header("Dynamic setting")]
    public float cameraZ;

    private void Awake()
    {
        cameraZ = transform.position.z;
    }

    private void FixedUpdate()
    {
        Vector3 destiny;
        if (target==null)
        {
            destiny=Vector3.zero;
            Cannon.blockShoot = false;
        }
        else
        {
            destiny = target.transform.position;
            if (target.CompareTag("Bullet"))
            {
                var sleeping = target.GetComponent<Rigidbody>().IsSleeping();
                if (sleeping)
                {
                    target = null;
                    destiny=Vector3.zero;
                    Cannon.blockShoot = false;
                    return;
                }
            }
        }
        destiny.x = Mathf.Max(limitXY.x, destiny.x);
        destiny.y = Mathf.Max(limitXY.y, destiny.y);
        destiny=Vector3.Lerp(transform.position, destiny, smoothing);
        destiny.z = cameraZ;
        transform.position = destiny;
        if (Camera.main!=null) Camera.main.orthographicSize = destiny.y + 20;
    }

}
