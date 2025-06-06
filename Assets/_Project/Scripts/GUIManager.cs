using UnityEngine;
using TMPro;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class GUIManager : MonoBehaviour
    {
        public static GUIManager Instance { get; private set; }

        [SerializeField]
        private TextMeshProUGUI coinBalance;
        
        [SerializeField]
        private TextMeshProUGUI coinPerClick;
        
        [SerializeField]
        private TextMeshProUGUI coinPerSecond;

        void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        
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
    }
}
