using UnityEngine;

public class RadarAskQuestion : MonoBehaviour
{
    public GameObject screen;
    public GameObject questions;

    public GameObjectiveManager gameManager;

    private Animator animator;
    private GameObject activeQuestion;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AskQuestion(int ID)
    {
        screen.SetActive(false);
        activeQuestion = questions.transform.GetChild(ID).gameObject;
        activeQuestion.SetActive(true);
        animator.SetBool("GetBig", true);
        Time.timeScale = 0.0f;              //Red light

        gameManager.CompletedObjective(ID);
    }

    public void CloseQuestions()
    {
        screen.SetActive(true);

        activeQuestion.SetActive(false);
        animator.SetBool("GetBig", false);
        Time.timeScale = 1.0f;              //Green light

        gameManager.EndCheck();
    }
}
