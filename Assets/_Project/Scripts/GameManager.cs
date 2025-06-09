using System;
using System.Collections;
using UnityEngine;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [Header("Game")]
        [SerializeField]
        private double coinBalance = 0;

        [SerializeField]
        private double coinPerClick = 1.0f;

        [SerializeField]
        private double coinPerSecond = 1.0f;

        [Header("Saving")]
        [SerializeField]
        private bool loadSaveOnStart = true;
        
        [SerializeField]
        private bool autoSaveEnabled = true;

        [SerializeField]
        private float saveEachSeconds = 5.0f;

        public double CoinBalance
        {
            private set => coinBalance = value;
            get => coinBalance;
        }

        public double CoinPerClick
        {
            private set => coinPerClick = value;
            get => coinPerClick;
        }

        public double CoinPerSecond
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

        void Start()
        {
            if (loadSaveOnStart && SaveManager.Instance.IsSaveFound)
            {
                SaveData saveData = SaveManager.Instance.GetSaveData();
                CoinBalance = saveData.coinBalance;
                CoinPerClick = saveData.coinPerClick;
                CoinPerSecond = saveData.coinPerSecond;
            }

            StartCoroutine(SaveToFile());
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

        private void OnDisable()
        {
            SaveGameProgress();
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
            else if (upgradeType == UpgradeType.PassiveIncome)
                CoinPerSecond += effect;
        }

        private void SaveGameProgress()
        {
            SaveManager.Instance.SaveToFile(CoinBalance, CoinPerClick, CoinPerSecond);
        }

        IEnumerator SaveToFile()
        {
            while (autoSaveEnabled)
            {
                yield return new WaitForSeconds(saveEachSeconds);
                SaveGameProgress();
            }
        }
    }
}
