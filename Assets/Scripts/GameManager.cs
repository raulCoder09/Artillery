using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public static int speedBall=30;

    public static int shootsByGame=10;

    public static float speedRotation=1f;
    private void Awake()
    {
        if (gameManager==null)
        {
            gameManager = this;
        }
        else
        {
            print("singleton instance exist!!");
        }
    }

}
