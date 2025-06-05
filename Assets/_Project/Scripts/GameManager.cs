using UnityEngine;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
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

        public static GameManager Instance { get; private set; }

        #endregion

        #region Constants

        // public const float MyPublicConst = 20.0f;
        // private const float MyPrivateConst = 15.0f;

        #endregion

        #region Serialized Fields

        [SerializeField]
        private float coinBalance = 0;

        [SerializeField]
        private float coinPerClick = 1.0f;

        [SerializeField]
        private float coinPerSecond = 1.0f;

        #endregion

        #region Private Fields

        // private int _myPrivateInt = 10;

        #endregion

        #region Public Fields
        // public float myPublicFloat = 10.0f;
        #endregion

        #region Properties

        public float CoinBalance
        {
            private set => coinBalance = value;
            get => coinBalance;
        }

        public float CoinPerClick
        {
            private set => coinPerClick = value;
            get => coinPerClick;
        }

        public float CoinPerSecond
        {
            private set => coinPerSecond = value;
            get => coinPerSecond;
        }
        
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
                Destroy(this);
                return;
            }
            Instance = this;
        }
        
        void OnEnable(){}

        void Start()
        {
            
        }

        void FixedUpdate()
        {
            CoinBalance += CoinPerSecond * Time.fixedDeltaTime;
        }

        void Update()
        {
            
        }

        void LateUpdate()
        {
            GUIManager.Instance.SetCoinBalance(CoinBalance);
            GUIManager.Instance.SetCoinPerClick(CoinPerClick);
            GUIManager.Instance.SetCoinPerSecond(CoinPerSecond);
        }
        
        void OnDisable(){}
        
        void OnDestroy(){}
        
        
        void OnBecameVisible(){}
        
        void OnBecameInvisible(){}
        
        void OnApplicationPause(bool pauseStatus){}
        
        void OnApplicationFocus(bool focusStatus){}
        
        void OnApplicationQuit(){}
        #endregion

        #region Public Methods

        public void CountOneClick()
        {
            CoinBalance += CoinPerClick;
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
