using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetObject;
    [Range(0, 1)] public float trackingFactor = 0.15f;
    [Range(0, 180)] public float angle = 55;
    public float distance;

    private Vector3 offset;
    private Vector3 avgPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateOffsets();

        avgPosition = targetObject.transform.position;
    }

    private void FixedUpdate()
    {
        UpdateOffsets();

        Vector3 newPosition = targetObject.transform.position;
        //avgPosition = newPosition * trackingFactor + (1.0f - trackingFactor) * avgPosition;
        //avgPosition = math.lerp(avgPosition, newPosition, trackingFactor);
        avgPosition = avgPosition + (newPosition - avgPosition) * trackingFactor;
        transform.position = avgPosition + offset;
    }

    private void UpdateOffsets()
    {
        offset = new Vector3(0, (float)Math.Sin(angle * Math.PI / 180), (float)-Math.Cos(angle * Math.PI / 180)) * distance;
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}