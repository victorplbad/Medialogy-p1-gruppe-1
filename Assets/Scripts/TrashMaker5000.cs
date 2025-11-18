using Unity.Mathematics;
using UnityEngine;

public class TrashMaker5000 : MonoBehaviour
{
    public GameObject trashPrefab;

    
    public Vector3 minPosition;
    public Vector3 maxPosition;

    public int trashMax = 100;
    public int trashPerFrame = 0;
    private int trashCount = 0;

    void Start()
    {
        int i = 0;
        while(i <= trashMax)
        {
            GenerateTrash();
            i++;
        }
    }

    private void FixedUpdate()
    {
        for (int i = math.min(trashMax - trashCount, trashPerFrame); i > 0 ; i--)
        {
            GenerateTrash();
        }
    }

    public void GenerateTrash()
    {
        Vector3 randomPosition = new Vector3
            (
            UnityEngine.Random.Range(minPosition.x, maxPosition.x),
            UnityEngine.Random.Range(minPosition.y, maxPosition.y),
            UnityEngine.Random.Range(minPosition.z, maxPosition.z)
            );

        GameObject trash = Instantiate(trashPrefab, randomPosition, Quaternion.identity);
        if (trash)
        {
            Rigidbody body = trash.GetComponent<Rigidbody>();
            body.mass = UnityEngine.Random.Range(1, 10);
            trash.transform.localScale = trash.transform.localScale * math.sqrt(body.mass);
            trashCount++;
        }
    }

    public float KillTrash(GameObject trash)
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
