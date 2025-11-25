using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CharacterController : MonoBehaviour
{
    public TrashMaker5000 trashFactory;

    public TextMeshProUGUI scoreTracker;

    public GameObject streg;

    public float topSpeed = 100f;
    public float turningFactor = 0.08f;

    private float score = 0;

    float speedFraction;
    float avgTurn;

    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        speedFraction = math.clamp(speedFraction + y * Time.deltaTime, 0, 1);
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
            scoreTracker.text = score.ToString();
            //scoreTracker.fontStyle ^= FontStyles.Strikethrough;
        }

        if (collision.gameObject.CompareTag("trashCheckpoint"))
        {//Put function to quizz here
            scoreTracker.text = "WOOOW!";
            Destroy(collision.gameObject);
        }
    }
}
