using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace TestClicker
{
    /// <summary>
    /// Description
    /// </summary>
    [DisallowMultipleComponent]
    public class Upgrade : MonoBehaviour
    {
        #region DELETE

        /// <summary>
        /// Сначала описание методов, полей и свойств, потом теги
        /// </summary>
        // [SerializeField]       // +serialization, +inspector
        // [NonSerialized]        // -serialization, -inspector
        // [HideInInspector]      // -inspector
        // [Range(0.0f, 10.0f)]   // Range from 0 to 10
        // [Tooltip("Some Text")] // Adds tooltip on hover
        // [Space(10)]            // Vertical margin of 10px
        // [TextArea(3, 10)]      // TextArea of 3 to 10 rows
        // [ContextMenu("Add 10 to Some Value")] // Makes this method callable from Inspector
        // [Header("CustomHeader")] // Custom Header

        #endregion

        #region Static Fields

        // public static float MyPublicStatic = 10.0f;
        // private static float MyPrivateStatic = 10.0f;

        #endregion

        #region Constants

        // public const float MyPublicConst = 20.0f;
        // private const float MyPrivateConst = 15.0f;

        #endregion

        #region Serialized Fields

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
        
        #endregion

        #region Private Fields
        
        private Button _button;
        private Image _icon;
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _description;
        private TextMeshProUGUI _price;

        #endregion

        #region Public Fields

        // public float myPublicFloat = 10.0f;

        #endregion

        #region Properties

        // public int Value1
        // {
        //     get => _value1 * 2;
        //     set => _value1 = value + 10;
        // }
        // public int Value2
        // {
        //     get
        //     {
        //         // Стандартный геттер, возвращает значение
        //         return _value1 * 2;
        //     }
        //     set
        //     {
        //         // Сеттер добавляет 10 к входному значению
        //         _value1 = value + 10;
        //     }
        // }

        #endregion

        #region Events & Delegates

        //

        #endregion

        #region Constructors

        // public MyTemplate(){}

        #endregion

        #region Unity Lifecycle

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

        void Start()
        {
        }

        void FixedUpdate()
        {
            
        }

        void Update()
        {
            if (GameManager.Instance.CoinBalance < price)
                _button.interactable = false;
            else
                _button.interactable = true;
        }

        void LateUpdate()
        {
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(BuyUpgrade);
        }

        void OnDestroy()
        {
        }


        void OnBecameVisible()
        {
        }

        void OnBecameInvisible()
        {
        }

        void OnApplicationPause(bool pauseStatus)
        {
        }

        void OnApplicationFocus(bool focusStatus)
        {
        }

        void OnApplicationQuit()
        {
        }

        #endregion

        #region Public Methods

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

        #endregion

        #region Private Methods

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

        #endregion

        #region Coroutines

        // private Coroutine _myCoroutine = StartCoroutine(SomeCoroutine());
        // IEnumerator SomeCoroutine()
        // {
        //     yield return new WaitForSeconds(1);
        //     yield return new WaitForSecondsRealtime(1);
        //     yield return null;
        //     yield break;
        // }

        #endregion

        #region Enums

        // public enum MyPublicEnum{}
        // private enum MyPrivateEnum{}

        #endregion

        #region Classes

        // classes

        #endregion
    }
}