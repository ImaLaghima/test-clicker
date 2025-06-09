using UnityEngine;

namespace TestClicker
{
    [CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
    public class UpgradeData : ScriptableObject
    {
        public Sprite icon;
        public string title;
        public string description;
        public float price;
        public UpgradeType type;
        public float effect;
    }
    
    public enum UpgradeType
    {
        ClickBoost,
        PassiveIncome
    }
}
