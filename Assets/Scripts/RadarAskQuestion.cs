using UnityEngine;

public class RadarAskQuestion : MonoBehaviour
{
    public GameObject screen;
    public GameObject questions;

    public GameManager gameManager;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AskQuestion(int ID)
    {
        screen.SetActive(false);
        questions.transform.GetChild(ID).gameObject.SetActive(true);
        animator.SetBool("GetBig", true);
        Time.timeScale = 0.0f;              //Red light

        gameManager.CompletedObjective(ID);
    }

    public void CloseQuestions()
    {
        screen.SetActive(true);
        for (int i = 0; i < questions.transform.childCount; i++)
        {
            questions.transform.GetChild(i).gameObject.SetActive(false);
        }
        animator.SetBool("GetBig", false);
        Time.timeScale = 1.0f;              //Green light

        gameManager.TrueEnding();
    }
}
