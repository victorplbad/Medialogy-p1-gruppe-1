using UnityEngine;

public class BoatWobble : MonoBehaviour
{
    public float wobbleAmplitude = 2f;
    public float wobbleSpeed = 1.5f;
    
    void Update()
    {
        float wobble = Mathf.Cos(Time.time * wobbleSpeed) * wobbleAmplitude;
        //transform.Rotate(new Vector3(0, 0, wobble));
        Vector3 angle = transform.localEulerAngles;
        angle.x = 0;
        angle.z = wobble;
        transform.localEulerAngles = angle;
    }
}
