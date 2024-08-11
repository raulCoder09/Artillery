using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _Scripts.Ui.GameOver
{
    public class GameOver : MonoBehaviour
    {
        private UIDocument _uIDocument;
        private static VisualElement _root;
        private static bool _uiActive;
        private void OnEnable()
        {
            _uIDocument = FindUIDocument("GameOver");
            if (_uIDocument != null)
            {
                _root = _uIDocument.rootVisualElement;
            }
            ConfigureUIElements();
        }
        private void Start()
        {
            Hide();
        }
        private void ConfigureUIElements()
        {
            if (_root==null) return;
            var playAgain = _root?.Q<Button>("PlayAgain");
            if (playAgain!=null)playAgain.clicked += TryAgain;
            var levelsMenu = _root?.Q<Button>("LevelsMenu");
            if (levelsMenu!=null)levelsMenu.clicked += ShowLevelsMenu;
            var exit = _root?.Q<Button>("Exit");
            if (exit!=null)exit.clicked += ExitApplication;
        }
        private void ExitApplication()
        {
            Application.Quit();
        }
        private void ShowLevelsMenu()
        {
            Hide();
            Levels.Levels.Show();
        }
        private void TryAgain()
        {
            Hide();
            GameManager.LevelNumber = 1;
            SceneManager.LoadScene("Level1");
            switch (GameManager.LevelNumber)
            {
                case 1:
                    GameManager.ShootsByGame = 15;
                    Target.Life = 5;
                    break;
                case 2:
                    GameManager.ShootsByGame = 15;
                    Target.Life = 10;
                    break;
                case 3:
                    GameManager.ShootsByGame = 15;
                    Target.Life = 15;
                    break;
                case 4:
                    GameManager.ShootsByGame = 15;
                    Target.Life = 20;
                    break;
                case 5:
                    GameManager.ShootsByGame = 15;
                    Target.Life = 25;
                    break;
            }
            Game.Game.Show();
        }
        internal static void Show()
        {
            _uiActive = true;
            if (_root!=null)
            {
                _root.style.display = DisplayStyle.Flex;
            }
        }
        private void Hide()
        {
            _uiActive = false;
            if (_root!=null)
            {
                _root.style.display = DisplayStyle.None;
            }
        }
        private UIDocument FindUIDocument(string nameUiDocument)
        {
            var uiDocument = GameObject.Find(nameUiDocument)?.GetComponent<UIDocument>();
            if (uiDocument==null)
            {
                Debug.Log($"Error {nameUiDocument} UI Document");
            }
            return uiDocument;
        }
    }
}
