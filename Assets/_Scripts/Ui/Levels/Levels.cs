using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Levels
{
    public class Levels : MonoBehaviour
    {
        private UIDocument _uIDocument;
        private static VisualElement _root;
        private static bool _uiActive;
        private void Awake()
        {
            _uIDocument = FindUIDocument("Levels");
            if (_uIDocument != null)
            {
                _root = _uIDocument.rootVisualElement;
            }
        }
        private void OnEnable()
        {
            ConfigureUIElements();
        }
        private void Start()
        {
            Hide();
        }
        private void Update()
        {
            switch (GameManager.LevelNumber)
            {
                case 2:
                    if (_root==null)return;
                    _root.Q<Button>("Level2").enabledSelf = true;
                    break;
                case 3:
                    if (_root==null)return;
                    _root.Q<Button>("Level3").enabledSelf = true;
                    break;
                case 4:
                    if (_root==null)return;
                    _root.Q<Button>("Level4").enabledSelf = true;
                    break;
                case 5:
                    if (_root==null)return;
                    _root.Q<Button>("Level5").enabledSelf = true;
                    break;

            }
        }
        private void ConfigureUIElements()
        {
            if (_root==null) return;
            var welcome = _root?.Q<Button>("Welcome");
            if (welcome!=null)welcome.clicked += ShowWelcome;
            var options = _root?.Q<Button>("Options");
            if (options!=null)options.clicked += ShowOptions;
            var exit = _root?.Q<Button>("Exit");
            if (exit!=null)exit.clicked += ExitApplication;
            var buttonLevel1 = _root?.Q<Button>("Level1");
            if (buttonLevel1!=null) buttonLevel1.clicked += ShowLevel1;
            var buttonLevel2 = _root?.Q<Button>("Level2");
            if (buttonLevel2!=null) buttonLevel2.clicked += ShowLevel2;
            var buttonLevel3 = _root?.Q<Button>("Level3");
            if (buttonLevel3!=null) buttonLevel3.clicked += ShowLevel3;
            var buttonLevel4 = _root?.Q<Button>("Level4");
            if (buttonLevel4!=null) buttonLevel4.clicked += ShowLevel4;
            var buttonLevel5 = _root?.Q<Button>("Level5");
            if (buttonLevel5!=null) buttonLevel5.clicked += ShowLevel5;
        }
        private void ShowLevel1()
        {
            GameManager.LevelNumber = 1;
            GameManager.ShootsByGame = 3;
            Target.Life = 2;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level1")
            {
                SceneManager.LoadScene($"Level1");
            }
            Hide();
            Game.Game.Show();
        }
        private void ShowLevel2()
        {
            GameManager.LevelNumber = 2;
            GameManager.ShootsByGame = 15;
            Target.Life = 10;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level2")
            {
                SceneManager.LoadScene($"Level2");
            }
            Hide();
            Game.Game.Show();
        }
        private void ShowLevel3()
        {
            GameManager.LevelNumber = 3;
            GameManager.ShootsByGame = 15;
            Target.Life = 15;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level3")
            {
                SceneManager.LoadScene($"Level3");
            }
            Hide();
            Game.Game.Show();
        }
        private void ShowLevel4()
        {
            GameManager.LevelNumber = 4;
            GameManager.ShootsByGame = 15;
            Target.Life = 20;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level4")
            {
                SceneManager.LoadScene($"Level4");
            }
            Hide();
            Game.Game.Show();
        }
        private void ShowLevel5()
        {
            GameManager.LevelNumber = 5;
            GameManager.ShootsByGame = 100;
            Target.Life = 90;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level5")
            {
                SceneManager.LoadScene($"Level5");
            }
            Hide();
            Game.Game.Show();
        }
        private void ExitApplication()
        {
            Application.Quit();
        }
        private void ShowWelcome()
        {
            Hide();
            Welcome.Welcome.Show();
        }
        private void ShowOptions()
        {
            Hide();
            Options.Options.Show();
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
