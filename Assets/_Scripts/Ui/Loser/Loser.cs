using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Loser
{
    public class Loser : MonoBehaviour
    {
        private UIDocument _uIDocument;
        private static VisualElement _root;
        private static bool _uiActive;
        private void OnEnable()
        {
            _uIDocument = FindUIDocument("Loser");
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
            var tryAgain = _root?.Q<Button>("TryAgain");
            if (tryAgain!=null)tryAgain.clicked += TryAgain;
            var exit = _root?.Q<Button>("Exit");
            if (exit!=null)exit.clicked += ExitApplication;
        }
        private void ExitApplication()
        {
            Application.Quit();
        }
        private void TryAgain()
        {
            Hide();
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            SceneManager.LoadScene(sceneName);
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
