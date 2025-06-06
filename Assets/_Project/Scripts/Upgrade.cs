using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class Upgrade : MonoBehaviour
    {
        [SerializeField]
        private Sprite icon;

        [SerializeField]
        private float price;

        [SerializeField]
        private string title;
        
        [SerializeField]
        [TextArea(3, 10)]
        private string description;
        
        [SerializeField]
        private UpgradeType type;

        [SerializeField]
        private float effect;

        private Button _button;
        private Image _icon;
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _description;
        private TextMeshProUGUI _price;

        void Awake()
        {
            _button = GetComponent<Button>();
            _icon = transform.Find("Icon").GetComponent<Image>();
            _title = transform.Find("Title").GetComponent<TextMeshProUGUI>();
            _description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
            _price = transform.Find("Price").GetComponent<TextMeshProUGUI>();
        }

        void OnEnable()
        {
            _button.onClick.AddListener(BuyUpgrade);
            RefreshGUI();
        }

        void Update()
        {
            if (GameManager.Instance.CoinBalance < price)
                _button.interactable = false;
            else
                _button.interactable = true;
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(BuyUpgrade);
        }

        public void Setup(UpgradeData data)
        {
            icon = data.icon;
            title = data.title;
            description = data.description;
            price = data.price;
            type = data.type;
            effect = data.effect;
            RefreshGUI();
        }

        public void Activate()
        {
            _button.interactable = true;
        }

        public void Deactivate()
        {
            _button.interactable = false;
        }

        private void BuyUpgrade()
        {
            GameManager.Instance.ApplyUpgrade(price, type, effect);
        }

        private void RefreshGUI()
        {
            _icon.sprite = icon;
            _title.text = title;
            _description.text = description;
            _price.text = price.ToString();
        }
    }
}