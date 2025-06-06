using UnityEngine;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField]
        private float coinBalance = 0;

        [SerializeField]
        private float coinPerClick = 1.0f;

        [SerializeField]
        private float coinPerSecond = 1.0f;

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

        void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        void Update()
        {
            CoinBalance += CoinPerSecond * Time.deltaTime;
        }

        void LateUpdate()
        {
            GUIManager.Instance.SetCoinBalance(CoinBalance);
            GUIManager.Instance.SetCoinPerClick(CoinPerClick);
            GUIManager.Instance.SetCoinPerSecond(CoinPerSecond);
        }

        public void CountOneClick()
        {
            CoinBalance += CoinPerClick;
        }

        public void ApplyUpgrade(float price, UpgradeType upgradeType, float effect)
        {
            CoinBalance -= price;
            if (upgradeType == UpgradeType.ClickBoost)
                CoinPerClick += effect;
            else
                CoinPerSecond += effect;
        }
    }
}
