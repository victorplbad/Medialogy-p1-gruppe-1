using UnityEngine;

public class AskAQQuestion : MonoBehaviour
{
    public GameObject screen;
    public GameObject questions;

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
    }

    public void CloseQuestions()
    {
        screen.SetActive(true);
        for (int i = 0; i < questions.transform.childCount; i++)
        {
            questions.transform.GetChild(i).gameObject.SetActive(false);
        }
        animator.SetBool("GetBig", false);
    }
}
