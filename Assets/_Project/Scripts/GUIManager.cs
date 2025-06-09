using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class GUIManager : MonoBehaviour
    {
        public static GUIManager Instance { get; private set; }
        
        [SerializeField]
        private VisualTreeAsset upgradeTemplate;
        
        [SerializeField]
        private List<UpgradeData> upgrades;
        
        private UIDocument _uiDocument;
        private Label _coinBalanceLabel;
        private Label _coinPerClickLabel;
        private Label _coinPerSecondLabel;
        private Label _shopTitle;
        private ScrollView _scrollView;

        private Button _englishLocalButton;
        private Button _spanishLocalButton;
        
        private List<UpgradeController> _upgradeControllers;

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
            _scrollView = _uiDocument.rootVisualElement.Q<ScrollView>("scroll-view");
            _shopTitle = _uiDocument.rootVisualElement.Q<Label>("shop-title");
            _shopTitle.text = LocalizationManager.Instance.GetLocalizedText("shop_title_key");
            
            _englishLocalButton = _uiDocument.rootVisualElement.Q<Button>("english-local-button");
            _englishLocalButton.RegisterCallback<ClickEvent>((ClickEvent evt) => {
                LocalizationManager.Instance.SetLanguage("English");
                RefreshLocal();
            });
            _spanishLocalButton = _uiDocument.rootVisualElement.Q<Button>("spanish-local-button");
            _spanishLocalButton.RegisterCallback<ClickEvent>((ClickEvent evt) => {
                LocalizationManager.Instance.SetLanguage("Spanish");
                RefreshLocal();
            });

            _upgradeControllers = new List<UpgradeController>();
            PopulateScrollView();
        }
        
        public void SetCoinBalance(double value)
        {
            _coinBalanceLabel.text = value.ToString();
        }

        public void SetCoinPerClick(double value)
        {
            _coinPerClickLabel.text = value.ToString();
        }

        public void SetCoinPerSecond(double value)
        {
            _coinPerSecondLabel.text = value.ToString();
        }

        private void Update()
        {
            double coinBalance = GameManager.Instance.CoinBalance;
            foreach (UpgradeController controller in _upgradeControllers)
                controller.UpdateItem(coinBalance);
        }

        private void PopulateScrollView()
        {
            foreach (UpgradeData upgradeData in upgrades)
            {
                VisualElement upgradeVisualElement = upgradeTemplate.Instantiate();
                UpgradeController upgradeController = new UpgradeController(
                    upgradeVisualElement,
                    upgradeData,
                    ((price, type, effect) =>
                    {
                        GameManager.Instance.ApplyUpgrade(price, type, effect);
                        AudioManager.Instance.PlayUpgradeSFX();
                    })
                );
                
                _upgradeControllers.Add(upgradeController);
                _scrollView.Add(upgradeVisualElement);
            }
        }

        private void RefreshLocal()
        {
            _shopTitle.text = LocalizationManager.Instance.GetLocalizedText("shop_title_key");
            foreach (UpgradeController controller in _upgradeControllers)
                controller.RefreshLocal();
        }
    }
}
