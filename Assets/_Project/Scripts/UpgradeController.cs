using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestClicker
{
    public class UpgradeController : VisualElement
    {
        private VisualElement _upgradeVisualElement; 
        private UpgradeData _upgradeData;
        private bool _isInteractable;
        private Action<float, UpgradeType, float> _onBuyCallback;

        private VisualElement _veil;
        private VisualElement _upgradeIcon;
        private Label _upgradeTitle;
        private Label _upgradeDescription;
        private Label _upgradePrice;

        public bool IsInteractable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                if (_isInteractable)
                    DeactivateVeil();
                else
                    ActivateVeil();
            }
        }

        public UpgradeController(
            VisualElement upgradeVisualElement,
            UpgradeData data,
            Action<float, UpgradeType, float> onBuyCallback
        )
        {
            _upgradeVisualElement = upgradeVisualElement;
            _veil = _upgradeVisualElement.Q<VisualElement>("veil");
            _upgradeIcon = _upgradeVisualElement.Q<VisualElement>("upgrade-icon");
            _upgradeTitle = _upgradeVisualElement.Q<Label>("upgrade-title");
            _upgradeDescription = _upgradeVisualElement.Q<Label>("upgrade-description");
            _upgradePrice = _upgradeVisualElement.Q<Label>("upgrade-price");
            
            _upgradeData = data;
            _upgradeIcon.style.backgroundImage = new StyleBackground(_upgradeData.icon);
            _upgradeTitle.text = LocalizationManager.Instance.GetLocalizedText(_upgradeData.title);
            _upgradeDescription.text = LocalizationManager.Instance.GetLocalizedText(_upgradeData.description);
            _upgradePrice.text = _upgradeData.price.ToString();
            
            _onBuyCallback = onBuyCallback;
            _upgradeVisualElement.RegisterCallback<ClickEvent>(OnItemClicked);
        }

        public void UpdateItem(float coinBalance)
        {
            if (coinBalance >= _upgradeData.price)
                IsInteractable = true;
            else
                IsInteractable = false;
        }

        public void RefreshLocal()
        {
            _upgradeTitle.text = LocalizationManager.Instance.GetLocalizedText(_upgradeData.title);
            _upgradeDescription.text = LocalizationManager.Instance.GetLocalizedText(_upgradeData.description);
        }

        public void Activate()
        {
            IsInteractable = true;
        }

        public void Deactivate()
        {
            IsInteractable = false;
        }

        private void OnItemClicked(ClickEvent evt)
        {
            if (IsInteractable)
                _onBuyCallback?.Invoke(_upgradeData.price, _upgradeData.type, _upgradeData.effect);
        }
        
        private void ActivateVeil()
        {
            _veil.RemoveFromClassList("veil-inactive");
            _veil.AddToClassList("veil-active");
        }

        private void DeactivateVeil()
        {
            _veil.RemoveFromClassList("veil-active");
            _veil.AddToClassList("veil-inactive");
        }
    }
}