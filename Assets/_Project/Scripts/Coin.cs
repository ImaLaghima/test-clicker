using UnityEngine;
using UnityEngine.Pool;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class Coin : MonoBehaviour
    {
        [SerializeField]
        private float force = 20;
        
        private IObjectPool<GameObject> _coinsPoolRef;
        private Rigidbody2D _rigidbody2d;

        void Awake()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }

        void OnEnable()
        {
            _rigidbody2d.AddForce(
                new Vector2(Random.Range(-20, 20), Random.Range(-20, 20)).normalized * force,
                ForceMode2D.Impulse
            );
        }
        
        void OnDisable()
        {
            _rigidbody2d.linearVelocity = Vector2.zero;
            _rigidbody2d.angularVelocity = 0.0f;
        }
        
        public void SetPool(IObjectPool<GameObject> pool)
        {
            _coinsPoolRef = pool;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Sensor"))
                _coinsPoolRef.Release(gameObject);
                    
        }
    }
}
