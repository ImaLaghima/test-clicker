using UnityEngine;
using UnityEngine.InputSystem;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class Target : MonoBehaviour
    {
        private static readonly int PopT = Animator.StringToHash("Pop_t");
        
        [SerializeField]
        private ParticleSystem clickEffect;
        
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void OnTargetClick(InputValue value)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider)
            {
                _animator.SetTrigger(PopT);
                ObjectPooler.Instance.GetCoin(hit.point);
                GameManager.Instance.CountOneClick();
                AudioManager.Instance.PlayCoinSFX();
                
                var effect = Instantiate(
                    clickEffect,
                    hit.point,
                    Quaternion.identity
                );
                effect.transform.SetParent(null);
                effect.Play();
            }
        }
    }
}
