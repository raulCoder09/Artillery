using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Winner
{
    public class Winner : MonoBehaviour
    {
        private UIDocument _uIDocument;
        private static VisualElement _root;
        private static bool _uiActive;
        private void OnEnable()
        {
            _uIDocument = FindUIDocument("Winner");
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
            var nextLevel = _root?.Q<Button>("NextLevel");
            if (nextLevel!=null)nextLevel.clicked += NextLevel;
            var levelsMenu = _root?.Q<Button>("LevelsMenu");
            if (levelsMenu!=null)levelsMenu.clicked += ShowLevelsMenu;
            var exit = _root?.Q<Button>("Exit");
            if (exit!=null)exit.clicked += ExitApplication;
        }
        private void NextLevel()
        {
            Hide();
            switch (GameManager.LevelNumber)
            {
                case 2:
                    GameManager.ShootsByGame = 15;
                    Target.Life = 5;
                    break;
                case 3:
                    GameManager.ShootsByGame = 15;
                    Target.Life = 5;
                    break;
                case 4:
                    GameManager.ShootsByGame = 15;
                    Target.Life = 5;
                    break;
                case 5:
                    GameManager.ShootsByGame = 100;
                    Target.Life = 90;
                    break;
            }
            Game.Game.Show();
            SceneManager.LoadScene($"Level{GameManager.LevelNumber}");
        }
        private void ShowLevelsMenu()
        {
            Hide();
            Levels.Levels.Show();
        }
        private void ExitApplication()
        {
            Application.Quit();
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
