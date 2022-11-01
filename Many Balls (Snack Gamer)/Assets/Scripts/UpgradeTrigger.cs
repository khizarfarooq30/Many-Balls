using System;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
    public static Action OnUpgradeTriggerEnter;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController playerController))
        {
            playerController.PlayerUpgradeEnterTrigger(transform.position, Quaternion.Euler(0f, -90f, 0f));
            OnUpgradeTriggerEnter?.Invoke();
        }
    }
}
