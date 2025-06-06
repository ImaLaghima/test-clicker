using UnityEngine;
using UnityEngine.Pool;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler Instance { get; private set; }

        [SerializeField]
        private GameObject coinPrefab;
        
        [SerializeField]
        private int defaultPoolSize = 20;
        
        [SerializeField]
        private int maxPoolSize = 100;

        private ObjectPool<GameObject> _coinsPool;
        private int _currentPoolSize;
        
        void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        void Start()
        {
            _coinsPool = new ObjectPool<GameObject>(
                createFunc: CreateCoin,
                actionOnGet: OnGetCoin,
                actionOnRelease: OnReleaseCoin,
                actionOnDestroy: OnDestroyCoin,
                collectionCheck: true,
                defaultCapacity: defaultPoolSize,
                maxSize: maxPoolSize
            );
        }

        public GameObject GetCoin(Vector3 position)
        {
            GameObject coin = _coinsPool.Get();
            coin.transform.position = position;
            return coin;
        }

        private GameObject CreateCoin()
        {
            GameObject coin = Instantiate(coinPrefab, transform, true);
            coin.GetComponent<Coin>().SetPool(_coinsPool);
            return coin;
        }

        private void OnGetCoin(GameObject coin)
        {
            coin.SetActive(true);
        }

        private void OnReleaseCoin(GameObject coin)
        {
            coin.SetActive(false);
        }

        private void OnDestroyCoin(GameObject coin)
        {
            if (Application.isPlaying)
                Destroy(coin);
        }
    }
}
