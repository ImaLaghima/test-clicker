using System.Collections.Generic;
using UnityEngine;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class ShopManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject upgradePrefab;
        
        [SerializeField]
        private List<UpgradeData> upgrades;
        
        [SerializeField]
        private GameObject shopContent;

        void Start()
        {
            foreach (UpgradeData upgradeItem in upgrades)
            {
                GameObject newUpgrade = Instantiate(upgradePrefab, shopContent.transform);
                Upgrade upgradeComponent = newUpgrade.GetComponent<Upgrade>();
                upgradeComponent.Setup(upgradeItem);
            }
        }
    }
}
