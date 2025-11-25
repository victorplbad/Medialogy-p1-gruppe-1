using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public float timer = 0f;
    public float debrisSec = 0.64f;
    public float debrisTotal = 0f;
    public bool gameDone = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void gameDoneButton()
    {
        debrisTotal = timer * debrisSec; 
        Debug.Log(debrisTotal);
    }

}
