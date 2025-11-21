using UnityEngine;

public class GarbageDay : MonoBehaviour
{
    public float deleteInterval = 5;
    float timer = 0;
    TrashMaker5000 tm;

    private void Start()
    {
        tm = GameObject.FindGameObjectWithTag("Player").GetComponent<TrashMaker5000>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > deleteInterval)
        {
            timer -= deleteInterval;
            //Debug.Log((transform.position - tm.transform.position).magnitude);
            if((transform.position - tm.transform.position).magnitude > tm.maxTrashRadius)
            {
                tm.DestroyTrash(this.gameObject);
            }
        }
    }
}