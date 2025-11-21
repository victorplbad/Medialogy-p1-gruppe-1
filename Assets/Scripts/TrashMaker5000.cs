using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrashMaker5000 : MonoBehaviour
{
    public GameObject[] trashPrefabs;
    public GameObject player;
    
    public Vector3 minPosition;
    public Vector3 maxPosition;

    public float trashSpawnInterval = 100;
    public int trashPerInterval = 10;
    public int trashMax = 100;
    public int trashRadius = 500;
    public int maxTrashRadius = 1000;

    private Rigidbody body;

    private float trashSpawnWait = 0;
    private int trashCount = 0;

    void Start()
    {
        body = player.GetComponent<Rigidbody>();
        /*
        int i = 0;
        while(i <= trashMax)
        {
            GenerateTrash();
            i++;
        }*/
    }

    private void FixedUpdate()
    {
        trashSpawnWait += Time.deltaTime * body.linearVelocity.magnitude; 

        if (trashSpawnWait > trashSpawnInterval)
        {
            Debug.Log(trashCount);
            trashSpawnWait -= trashSpawnInterval;
            for (int i = math.min(trashMax - trashCount, trashPerInterval); i > 0; i--)
            {
                GenerateTrash();
            }
        }
    }

    public void GenerateTrash()
    {
        float angle = Random.Range(0, math.PI2);
        /*
        Vector3 randomPosition = transform.position + new Vector3
            (
            math.sin(angle) * trashRadius,
            0,
            math.cos(angle) * trashRadius
            );*/

        Vector3 randomPosition = transform.position + player.transform.forward * (trashRadius * Random.Range(1.0f, 1.2f)) + player.transform.right * (trashRadius * Random.Range(-0.6f, 0.6f));

        /*Vector3 randomPosition = transform.position + new Vector3
            (
            UnityEngine.Random.Range(minPosition.x, maxPosition.x),
            UnityEngine.Random.Range(minPosition.y, maxPosition.y),
            UnityEngine.Random.Range(minPosition.z, maxPosition.z)
            );*/

        GameObject prefab = trashPrefabs[Random.Range(0, trashPrefabs.Length)]; //Pick a random prefab

        GameObject trash = Instantiate(prefab, randomPosition, Quaternion.identity);
        trash.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);

        if (trash)
        {
            Rigidbody body = trash.GetComponent<Rigidbody>();
            //trash.transform.localScale = trash.transform.localScale * math.sqrt(body.mass);
            trashCount++;
        }
    }

    public float DestroyTrash(GameObject trash)
    {
        if (trash.CompareTag("trash"))
        {
            Destroy(trash);
            trashCount--;

            Rigidbody body = trash.GetComponent<Rigidbody>();
            return body.mass;
        }
        return 0.0f;
    }
}
