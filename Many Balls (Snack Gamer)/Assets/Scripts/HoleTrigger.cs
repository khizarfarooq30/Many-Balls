using System;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public static Action OnBallDrop;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            OnBallDrop?.Invoke();
        }
    }
}
