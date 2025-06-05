using UnityEngine;
using TMPro;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class GUIManager : MonoBehaviour
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

        public static GUIManager Instance { get; private set; }

        #endregion

        #region Constants

        // public const float MyPublicConst = 20.0f;
        // private const float MyPrivateConst = 15.0f;

        #endregion

        #region Serialized Fields

        [SerializeField]
        private TextMeshProUGUI coinBalance;
        
        [SerializeField]
        private TextMeshProUGUI coinPerClick;
        
        [SerializeField]
        private TextMeshProUGUI coinPerSecond;

        #endregion

        #region Private Fields

        // private int _myPrivateInt = 10;

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
        // C#
        // public delegate void TestDelegate(int number);
        // public event TestDelegate MonoTestEvent;
        // UnityEvent
        // public UnityEvent<int> unityTestEvent = new UnityEvent<int>();
        // public static UnityEvent<int> UnityStaticTestEvent = new UnityEvent<int>();
        #endregion

        #region Constructors
        // public MyTemplate(){}
        #endregion

        #region Unity Lifecycle

        void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        
        void OnEnable(){}
        
        void Start(){}
        
        void FixedUpdate(){}
        
        void Update(){}
        
        void LateUpdate(){}
        
        void OnDisable(){}
        
        void OnDestroy(){}
        
        
        void OnBecameVisible(){}
        
        void OnBecameInvisible(){}
        
        void OnApplicationPause(bool pauseStatus){}
        
        void OnApplicationFocus(bool focusStatus){}
        
        void OnApplicationQuit(){}
        #endregion

        #region Public Methods

        public void SetCoinBalance(float value)
        {
            coinBalance.text = value.ToString();
        }

        public void SetCoinPerClick(float value)
        {
            coinPerClick.text = value.ToString();
        }

        public void SetCoinPerSecond(float value)
        {
            coinPerSecond.text = value.ToString();
        }
        
        #endregion
        
        #region Private Methods
        // private static void SomeStaticMethod(){}
        // private void SomePublicMethod(){}
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
