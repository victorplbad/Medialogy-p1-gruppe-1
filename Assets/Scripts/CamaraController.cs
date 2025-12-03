using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetObject;                     //What are we looking at?
    [Range(0, 1)] public float trackingFactor = 0.15f;  //0: no tracking 1: instant snap to target
    [Range(0, 180)] public float angle = 55;            //Downward look angle
    public float distance;                              //Distance from target

    private Vector3 offset;
    private Vector3 avgPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateOffsets();

        avgPosition = targetObject.transform.position;  //Set initial position so we dont start by panning from 0, 0, 0
    }

    private void FixedUpdate()
    {
        //UpdateOffsets();                              //This is useful to test different camera angles

        Vector3 newPosition = targetObject.transform.position;
        //avgPosition = newPosition * trackingFactor + avgPosition * (1.0f - trackingFactor);
        //avgPosition = avgPosition + (newPosition - avgPosition) * trackingFactor;
        avgPosition = math.lerp(avgPosition, newPosition, trackingFactor);
        transform.position = avgPosition + offset;
    }

    private void UpdateOffsets()
    {
        offset = new Vector3(0, (float)math.sin(angle * math.PI / 180), (float) -math.cos(angle * math.PI / 180));
        offset *= distance;
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
