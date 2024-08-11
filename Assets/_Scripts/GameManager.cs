using System;
using UnityEngine;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;

        private static int _speedBall=30;
        internal static int SpeedBall
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
    

        public static float speedRotation=1f;
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
