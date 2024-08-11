using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Game
{
    public class Game : MonoBehaviour
    {
        private UIDocument _uIDocument;
        private static VisualElement _root;
        internal static bool _uiActive;
        private void OnEnable()
        {
            _uIDocument = FindUIDocument("Game");
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
        private void Update()
        {
            if (!_uiActive) return;
            _root.Q<Label>("ShotsAvailable").style.color = GameManager.ShootsByGame<=2 ? Color.red : Color.green;
            _root.Q<Label>("ShotsAvailable").text = $"Shots Available: {GameManager.ShootsByGame}";
            _root.Q<Label>("PowerEnemy").text = $"Power enemy : {Target.Life}";
            _root.Q<Label>("Level").text = $"Level : {GameManager.LevelNumber}";
            switch (Target.Life)
            {
                case <= 0:
                    Hide();
                    if (GameManager.LevelNumber < 5)
                    {
                        GameManager.LevelNumber++;
                        Winner.Winner.Show();
                    }
                    else
                    {
                        GameOver.GameOver.Show();
                        GameManager.LevelNumber = 1;
                    }
                    break;
                case > 0 when GameManager.ShootsByGame<=0:
                    Hide();
                    Loser.Loser.Show();
                    break;
            }
        }
        private void ConfigureUIElements()
        {
            if (_root!=null)
            {
                var buttonMenu = _root.Q<Button>("ButtonMenu");
                if (buttonMenu!=null)
                {
                    buttonMenu.clicked += ShowPauseAndMenu;
                }
                
                var powerCannon  = _root.Q<SliderInt>("PowerCannon");
                if (powerCannon!=null)
                {
                    powerCannon.RegisterValueChangedCallback(evt =>
                    {
                        GameManager.SpeedBall = evt.newValue;
                        print(GameManager.SpeedBall);
                    });
                }
            }
        }
        private void ShowPauseAndMenu()
        {
            Hide();
            PauseAndMenu.PauseAndMenu.Show();
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
