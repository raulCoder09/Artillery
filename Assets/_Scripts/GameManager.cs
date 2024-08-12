using UnityEngine;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;

        private static float _speedBall=.25f;
        internal static float SpeedBall
        {
            get => _speedBall;
            set => _speedBall = value;
        }
        private int _shoots=3; 
        private static int _shootsByGame;
        internal static int ShootsByGame
        {
            get => _shootsByGame;
            set => _shootsByGame = value;
        }
    

        private static float _speedRotation=1f;
        internal static float SpeedRotation
        {
            get => _speedRotation;
            set => _speedRotation = value;
        }
        internal static int LevelNumber;
    
        private void Awake()
        {
            _shootsByGame = _shoots;
            if (gameManager==null)
            {
                gameManager = this;
            }
            else
            {
                print("singleton instance exist!!");
            }
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(GameObject.Find("Ui"));
        }
    }
}
