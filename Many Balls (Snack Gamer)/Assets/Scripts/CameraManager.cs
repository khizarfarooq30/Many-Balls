using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera upgradeCam;

    private void Start()
    {
        UpgradeTrigger.OnUpgradeTriggerEnter += EnableUpgradeCam;
        UpgradeManager.Instance.OnUpgradePanelClose += DisableUpgradeCam;
    }

    private void OnDestroy()
    {
        UpgradeTrigger.OnUpgradeTriggerEnter -= EnableUpgradeCam;
        UpgradeManager.Instance.OnUpgradePanelClose -= DisableUpgradeCam;
    }

    private void EnableUpgradeCam()
    {
        upgradeCam.Priority = 15;
    }
    
    private void DisableUpgradeCam()
    {
        upgradeCam.Priority = 5;
    }

}
