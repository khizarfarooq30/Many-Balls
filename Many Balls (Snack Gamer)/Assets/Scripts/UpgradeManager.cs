using System;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    
    public Action<UpgradeType,float> OnUpgradeButtonPressed;
    public Action OnUpgradePanelClose;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
    
    public bool CanUpgrade(float amount)
    {
        return CoinManager.Instance.HaveSufficientCoins(amount);
    }
    
    public void OnUpgradePanelCloseButtonPressed()
    {
        OnUpgradePanelClose?.Invoke();
    }
}
