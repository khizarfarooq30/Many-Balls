using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/New Upgrade Data", fileName = "New Upgrade")]
public class UpgradeDataSO : ScriptableObject
{
    public UpgradeType upgradeType;
    public float[] cost;
}

public enum UpgradeType
{
    BUCKET = 0,
    SPEED = 1,
    HEIGHT = 2,
}

