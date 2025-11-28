using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public TrashMaker5000 trashFactory;

    public GameObject[] quizObjects = new GameObject[9];

    public TextMeshProUGUI scoreTracker;

    public GameObject streg;

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


    // Update is called once per frame
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
            //scoreTracker.fontStyle ^= FontStyles.Strikethrough;
        }

        if (collision.gameObject.CompareTag("trashCheckpoint"))
        {//Put function to quizz here
            int ID = collision.gameObject.GetComponent<CheckpointID>().ID;

            if (ID < quizObjects.Length && quizObjects[ID]) quizObjects[ID].SetActive(true);
            
            Time.timeScale = 0f; // måske gøre det langsomt?

            /*switch (ID)
            {
                case 0:
                    scoreTracker.text = "Debug!";
                    break;
                case 1:
                    scoreTracker.text = "Plastic poser!";
                    break;
                case 2:
                    scoreTracker.text = "Fødevareemballage!";
                    break;
                case 3:
                    scoreTracker.text = "Plastic flaske!";
                    break;
                case 4:
                    scoreTracker.text = "Vatpinde!";
                    break;
                case 5:
                    scoreTracker.text = "Vådeservietter!";
                    break;
                case 6:
                    scoreTracker.text = "Tøj!";
                    break;
                case 7:
                    scoreTracker.text = "Plastic tandbørste!";
                    break;
                case 8:
                    scoreTracker.text = "Cigeratskodder!";
                    break;
                default:
                    scoreTracker.text = "Error";
                    break;
            }*/
            Destroy(collision.gameObject);
        }
    }
}
