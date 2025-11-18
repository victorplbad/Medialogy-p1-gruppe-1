using UnityEngine;

public class TrashMaker5000 : MonoBehaviour
{

    public GameObject Trash;

    
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public int spawnAmount = 100;


    void Start()
    {
       int i = 0;
        while(i <= spawnAmount)
        {
            Vector3 randomPosition = new Vector3
           (
           Random.Range(minPosition.x, maxPosition.x),
           Random.Range(minPosition.y, maxPosition.y),
           Random.Range(minPosition.z, maxPosition.z)
           );

            Instantiate(Trash, randomPosition, Quaternion.identity);
            i++;
        }

       
    }

    




}
