using Unity.Mathematics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float minSpeed = 0;
    public float maxSpeed = 5;
    public float turningFactor = 0.08f;

    float speed;
    float avgTurn;


    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //if (y != 0) speed = math.lerp(speed, (y + 1) * 5, 0.05f);
        speed = math.clamp(speed + y * Time.deltaTime * 1.5f, minSpeed, maxSpeed);
        avgTurn = math.lerp(avgTurn, x, turningFactor);

        transform.Rotate(new Vector3(0, avgTurn, 0));
        transform.Translate(new Vector3(0, 0, speed));
    }
}
