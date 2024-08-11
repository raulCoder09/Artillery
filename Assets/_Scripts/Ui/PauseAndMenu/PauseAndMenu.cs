using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.PauseAndMenu
{
    public class PauseAndMenu : MonoBehaviour
    {
        private UIDocument _uIDocument;
        private static VisualElement _root;
        private static bool _uiActive;
        private void OnEnable()
        {
            _uIDocument = FindUIDocument("PauseAndMenu");
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
            var resume = _root?.Q<Button>("Resume");
            if (resume!=null)resume.clicked += Resume;
            var levelsMenu = _root?.Q<Button>("LevelsMenu");
            if (levelsMenu!=null)levelsMenu.clicked += LevelsMenu;
            var exit = _root?.Q<Button>("Exit");
            if (exit!=null) exit.clicked += ExitApplication;
        }
        private void Resume()
        {
            Hide();
            Game.Game.Show();
        }
        private void LevelsMenu()
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
