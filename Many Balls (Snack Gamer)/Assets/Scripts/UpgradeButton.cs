using System.Globalization;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeDataSO upgradeDataSo;

    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI upgradePricetext;
    
    private int currentUpgradeIndex;

    private UpgradeManager upgradeManager;
    
    private void Start()
    {
        upgradeManager = UpgradeManager.Instance;
        UpdateVisuals();
    }

    void UpdateVisuals()
    {
        upgradeNameText.text = upgradeDataSo.upgradeType.ToString();
        upgradePricetext.text = upgradeDataSo.cost[currentUpgradeIndex].ToString(CultureInfo.InvariantCulture);
    }
    
    public void OnUpgradeButton()
    {
        if (currentUpgradeIndex < upgradeDataSo.cost.Length)
        {
            if (!upgradeManager.CanUpgrade(upgradeDataSo.cost[currentUpgradeIndex])) return;
        
            upgradeManager.OnUpgradeButtonPressed(upgradeDataSo.upgradeType, upgradeDataSo.cost[currentUpgradeIndex]);
            currentUpgradeIndex++;
            upgradePricetext.text = upgradeDataSo.cost[currentUpgradeIndex].ToString(CultureInfo.InvariantCulture);
        }
    }
}
