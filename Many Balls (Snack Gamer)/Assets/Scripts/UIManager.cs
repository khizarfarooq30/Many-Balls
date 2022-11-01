using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanelObj;

    void Start()
    {
        UpgradeTrigger.OnUpgradeTriggerEnter += ShowUpgradePanel;
        UpgradeManager.Instance.OnUpgradePanelClose += HideUpgradePanel;
    }

    private void OnDestroy()
    {
        UpgradeTrigger.OnUpgradeTriggerEnter -= ShowUpgradePanel;
        UpgradeManager.Instance.OnUpgradePanelClose -= HideUpgradePanel;
    }

    private void ShowUpgradePanel()
    {
        upgradePanelObj.SetActive(true);
    }
    
    private void HideUpgradePanel()
    {
        upgradePanelObj.SetActive(false);
    }
}
