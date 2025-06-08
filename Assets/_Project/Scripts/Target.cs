using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class Target : MonoBehaviour
    {
        private static readonly int PopT = Animator.StringToHash("Pop_t");
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
                HandleClick();
        }

        public void HandleClick()
        {
            _animator.SetTrigger(PopT);
            ObjectPooler.Instance.GetCoin(transform.position);
            GameManager.Instance.CountOneClick();
            AudioManager.Instance.PlayCoinSFX();
        }
    }
}
