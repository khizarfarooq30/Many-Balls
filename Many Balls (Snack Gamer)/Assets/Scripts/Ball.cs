using UnityEngine;

[SelectionBase]
public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private Collider ballCol;
    [SerializeField] private MeshRenderer ballMesh;
    
    public void ActivateRb()
    {
        ballCol.isTrigger = false;
        ballRb.useGravity = true;
    }

    public void AddForce(Transform otherTransform)
    {
        ballRb.AddForce(-otherTransform.forward * Random.Range(0.25f, 0.5f), ForceMode.Impulse);
    }

    public void UpdateColor(Color newColor)
    {
        ballMesh.material.color = newColor;
    }
}
