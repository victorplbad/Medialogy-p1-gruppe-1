using UnityEngine;
using UnityEngine.Playables;

public class RadarAskQuestion : MonoBehaviour
{
    public GameObject screen;
    public GameObject questions;
    public GameObject speechBubble;

    public GameObjectiveManager gameManager;

    private Animator animator;
    private GameObject activeQuestion;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public float TalkTrash(int ID)
    {
        GameObject obj = speechBubble.transform.GetChild(ID).gameObject;
        obj.GetComponent<PlayableDirector>().Play();
        return (float)obj.GetComponent<PlayableDirector>().duration;
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
