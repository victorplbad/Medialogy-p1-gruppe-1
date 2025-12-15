using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrashMaker5000 : MonoBehaviour
{
    public GameObject[] trashPrefabs;
    public GameObject player;
    public GameObject trashParent;

    public float trashSpawnInterval = 100;
    public int trashPerInterval = 10;
    public int trashMax = 100;
    public int trashRadius = 500;
    public int maxTrashRadius = 1000;

    private float trashSpawnWait = 0;
    private int trashCount = 0;
    private Rigidbody body;

    void Start()
    {
        body = player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        trashSpawnWait += Time.fixedDeltaTime * body.linearVelocity.magnitude;

        while (trashSpawnWait > trashSpawnInterval)
        {   //Using while in case of large movement steps so it can spawn trash multiple times per frame if needed
            trashSpawnWait -= trashSpawnInterval;
            for (int i = math.min(trashMax - trashCount, trashPerInterval); i > 0; i--)
            {
                GenerateTrash();
            }
        }
    }

    public void GenerateTrash()
    {
        Vector3 randomPosition = transform.position + player.transform.forward * trashRadius + player.transform.right * (trashRadius * Random.Range(-0.6f, 0.6f));
        randomPosition.y = 0;       //ensure it is spawned on the water plane as the boat wobble script messes with right direction vector

        GameObject prefab = trashPrefabs[Random.Range(0, trashPrefabs.Length)];         //Pick a random prefab
        GameObject trash = Instantiate(prefab, randomPosition, Quaternion.identity);
        if (trashParent) trash.transform.parent = trashParent.transform;

        trash.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);

        if (trash) trashCount++;
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
