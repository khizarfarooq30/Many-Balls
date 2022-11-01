using System;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private BoxCollider bucketCollider;
    [SerializeField] private GameObject[] buckets;
    private GameObject currentBucket;
    private int currentBucketIndex;
    
    private void Start()
    {
        UpgradeManager.Instance.OnUpgradeButtonPressed += OnUpgradeButtonPressed;

        currentBucket = buckets[currentBucketIndex];
    }

    private void OnDestroy()
    {
        UpgradeManager.Instance.OnUpgradeButtonPressed -= OnUpgradeButtonPressed;
    }

    private void OnUpgradeButtonPressed(UpgradeType upgradeType, float cost)
    {
        switch (upgradeType)
        {
            case UpgradeType.BUCKET:
                if (currentBucketIndex < buckets.Length - 1)
                {
                    currentBucket.SetActive(false);
                    currentBucketIndex++;
                }
                else
                {
                    break;
                }
               
                currentBucket = buckets[currentBucketIndex];
                currentBucket.SetActive(true);
                bucketCollider.size += Vector3.one * 0.4f;
                
                break;
            case UpgradeType.SPEED:
                playerController.IncrementSpeed();
                break;
            case UpgradeType.HEIGHT:
                transform.localScale += Vector3.one * 0.2f;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(upgradeType), upgradeType, null);
        }
    }
}
