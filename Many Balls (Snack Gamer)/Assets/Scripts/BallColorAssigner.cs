using UnityEngine;

public class BallColorAssigner : MonoBehaviour
{
    [SerializeField] private Ball[] balls;

    [SerializeField] private Gradient gradient;
    private float currentGradVal;
    
    private void Start()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdateColor(gradient.Evaluate(currentGradVal));
            currentGradVal = (float) i / balls.Length;
        }
    }
}
