using UnityEngine;
using UnityEngine.Pool;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class Coin : MonoBehaviour
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

        // [SerializeField]
        // private int myPrivateInt = 10;
        // [SerializeField]
        // private int _value1;

        #endregion

        #region Private Fields

        private IObjectPool<GameObject> _coinsPoolRef;
        private Rigidbody2D _rigidbody2d;

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
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }

        void OnEnable()
        {
            
        }

        void Start()
        {
            
        }
        
        void FixedUpdate(){}
        
        void Update(){}
        
        void LateUpdate(){}

        void OnDisable()
        {
            _rigidbody2d.linearVelocity = Vector2.zero;
            _rigidbody2d.angularVelocity = 0.0f;
        }
        
        void OnDestroy(){}
        
        
        void OnBecameVisible(){}
        
        void OnBecameInvisible(){}
        
        void OnApplicationPause(bool pauseStatus){}
        
        void OnApplicationFocus(bool focusStatus){}
        
        void OnApplicationQuit(){}
        #endregion

        #region Public Methods
        public void SetPool(IObjectPool<GameObject> pool)
        {
            _coinsPoolRef = pool;
        }
        #endregion
        
        #region Private Methods

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Sensor"))
                _coinsPoolRef.Release(gameObject);
                    
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
