using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Ui.Options
{
    public class Options : MonoBehaviour
    {
        private UIDocument _uIDocument;
        private static VisualElement _root;
        private static bool _uiActive;
        private void OnEnable()
        {
            _uIDocument = FindUIDocument("Options");
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
            if (_root!=null)
            {
            }
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
