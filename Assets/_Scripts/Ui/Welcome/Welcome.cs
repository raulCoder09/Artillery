using System;
using UnityEngine;
using UnityEngine.UIElements;
namespace _Scripts.Ui.Welcome
{
    public class Welcome : MonoBehaviour
    {
        private UIDocument _uIDocument;
        private static VisualElement _root;
        private static bool _uiActive;
        private void Awake()
        {
            _uIDocument = FindUIDocument("Welcome");
            if (_uIDocument != null)
            {
                _root = _uIDocument.rootVisualElement;
            }
            else
            {
                print("_uIDocument no configurado");
            }
        }
        private void OnEnable()
        {
            ConfigureUIElements();
        }
        private void Start()
        {
            Show();
        }
        private void ConfigureUIElements()
        {
            var launch = _root?.Q<Button>("Launch");
            if (launch!=null)launch.clicked += ShowLevelsMenu;
            var exit = _root?.Q<Button>("Exit");
            if (exit!=null) exit.clicked += ExitApplication;
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
