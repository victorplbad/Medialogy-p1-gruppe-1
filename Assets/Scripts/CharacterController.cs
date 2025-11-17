using Unity.Mathematics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float minSpeed = 0;
    public float maxSpeed = 10;

    float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        speed = math.clamp(speed + y * Time.deltaTime, minSpeed, maxSpeed);
        

        this.transform.Rotate(new Vector3(0, x, 0));
        this.transform.Translate(new Vector3(0, 0, speed));
    }
}
