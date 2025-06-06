using UnityEngine;
using UnityEngine.InputSystem;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class Target : MonoBehaviour
    {
        private void OnTargetClick(InputValue value)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Проверяем, попал ли луч в 2D-объект
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider)
                HandleClick();
        }

        public void HandleClick()
        {
            ObjectPooler.Instance.GetCoin(transform.position);
            GameManager.Instance.CountOneClick();
        }
    }
}
