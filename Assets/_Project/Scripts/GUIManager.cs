using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class GUIManager : MonoBehaviour
    {
        public static GUIManager Instance { get; private set; }
        
        private UIDocument _uiDocument;
        private Label _coinBalanceLabel;
        private Label _coinPerClickLabel;
        private Label _coinPerSecondLabel;

        void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        void Start()
        {
            _uiDocument = GetComponent<UIDocument>();
            _coinBalanceLabel = _uiDocument.rootVisualElement.Q<Label>("coin-balance");
            _coinPerClickLabel = _uiDocument.rootVisualElement.Q<Label>("coin-per-click");
            _coinPerSecondLabel = _uiDocument.rootVisualElement.Q<Label>("coin-per-sec");
        }
        
        public void SetCoinBalance(float value)
        {
            _coinBalanceLabel.text = value.ToString();
        }

        public void SetCoinPerClick(float value)
        {
            _coinPerClickLabel.text = value.ToString();
        }

        public void SetCoinPerSecond(float value)
        {
            _coinPerSecondLabel.text = value.ToString();
        }
    }
}
