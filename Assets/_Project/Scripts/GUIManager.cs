using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
        private ScrollView _scrollView;
        
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

            _upgradeControllers = new List<UpgradeController>();
            PopulateScrollView();
        }

        private void Update()
        {
            float coinBalance = GameManager.Instance.CoinBalance;
            foreach (UpgradeController controller in _upgradeControllers)
                controller.UpdateItem(coinBalance);
        }

        public void PopulateScrollView()
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
