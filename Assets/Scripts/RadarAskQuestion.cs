using System.Collections;
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

    public void TalkTrash(int ID)
    {   //Talk to the player about the checkpointTrash
        PlayableDirector director = speechBubble.transform.GetChild(ID).gameObject.GetComponent<PlayableDirector>();
        director.Play();
        StartCoroutine(DelayedQuestion((float)director.duration, ID));
    }

    IEnumerator DelayedQuestion(float delay, int ID)
    {   //Ask question after delay
        yield return new WaitForSeconds(delay);
        AskQuestion(ID);
    }

    public void AskQuestion(int ID)
    {   //Ask a question about checkpointTrash
        screen.SetActive(false);
        activeQuestion = questions.transform.GetChild(ID).gameObject;
        activeQuestion.SetActive(true);
        animator.SetBool("GetBig", true);
        Time.timeScale = 0.0f;              //Red light

        gameManager.CompletedObjective(ID);
    }

    public void CloseQuestions()
    {   //Return the screen to normal after question
        screen.SetActive(true);

        activeQuestion.SetActive(false);
        animator.SetBool("GetBig", false);
        Time.timeScale = 1.0f;              //Green light

        gameManager.EndCheck();
    }
}
