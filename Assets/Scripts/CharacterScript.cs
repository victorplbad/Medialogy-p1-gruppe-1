using Unity.Mathematics;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public TrashMaker5000 trashFactory;
    public GameObject radar;

    public float topSpeed = 100f;
    public float turningFactor = 0.08f;
    public float score = 0;

    float speedFraction;
    float avgTurn;

    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        speedFraction = math.clamp(speedFraction + y * Time.fixedDeltaTime, 0, 1);
        avgTurn = math.lerp(avgTurn, x, turningFactor);

        transform.Rotate(new Vector3(0, avgTurn, 0));
        //transform.Translate(new Vector3(0, 0, speed)); BAD
        //body.linearVelocity = Vector3.Lerp(body.linearVelocity, 60 * speed * transform.forward, 0.05f);
        body.AddForce(topSpeed * speedFraction * transform.forward - body.linearVelocity, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("trash") & trashFactory)
        {
            score += trashFactory.DestroyTrash(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("trashCheckpoint"))
        {//Put function to quizz here
            int ID = collision.gameObject.GetComponent<CheckpointID>().ID;

            radar.GetComponent<RadarAskQuestion>().TalkTrash(ID);
            Destroy(collision.gameObject);
        }
    }
}
