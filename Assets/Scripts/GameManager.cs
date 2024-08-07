using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private static int _speedBall=30;
    internal static int SpeedBall
    {
        get => _speedBall;
        set => _speedBall = value;
    }

    private static int _shootsByGame=10;
    internal static int ShootsByGame
    {
        get => _shootsByGame;
        set => _shootsByGame = value;
    }
    

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
