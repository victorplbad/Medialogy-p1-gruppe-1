using UnityEngine;

public class boatWobble : MonoBehaviour
{
    public float wobbleAmplitude = 2f;
    public float wobbleSpeed = 1.5f;
    
    void Update()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmplitude;
        transform.localRotation = Quaternion.Euler(0f, 0f, wobble);
    }
}
