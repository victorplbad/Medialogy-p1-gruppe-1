using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public float timer = 0f;
    public float debrisSec = 0.64f;
    public float debrisTotal = 0f;

    public int id = 0;
    public bool id1 = false;
    public bool id2 = false;
    public bool id3 = false;
    public bool id4 = false;
    public bool id5 = false;
    public bool id6 = false;
    public bool id7 = false;
    public bool id8 = false;

  


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void GetId(int id)
    {
        if (id == 1 )
        {
            id1 = true;
        }
        else if (id == 2)
        {
            id2 = true;
        }
        else if (id == 3)
        {
            id3 = true;
        }
        else if (id == 4)
        {
            id4 = true;
        }
        else if (id == 5)
        {
            id5 = true;
        }
        else if (id == 6)
        {
            id6 = true;
        }
        else if (id == 7)
        {
            id7 = true;
        }
        else if (id == 8)
        {
            id8 = true;
        }
        else
        {
            Debug.Log("error");
        }

        if (id1 == true && id2 == true && id3 == true && id4 == true && id5 == true && id6 == true && id7 == true && id8 == true) // game end
        {
            debrisTotal = timer * debrisSec;
            Debug.Log(debrisTotal);


            
            Time.timeScale = 0;
            // game end kode
        }

    }


   

}
