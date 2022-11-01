using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.AddForce(transform);
        }
    }
}
