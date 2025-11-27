using UnityEngine;
using UnityEngine.SceneManagement;

public class Animate : MonoBehaviour
{
    public Animator boatAnimator;
    public Animator fadeAnimator;
    public Animator textAnimator;
    public Animator buttonAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(boatAnimator.);
        /*if (animator.playbackTime)
        {

        }*/
    }

    public void PlayAnimation()
    {
        boatAnimator.SetBool("GO", true);
        textAnimator.SetBool("GO", true);
        buttonAnimator.SetBool("GO", true);
    }

    public void AnimationEvent(string name)
    {
        if (name == "boatDone")
        {
            fadeAnimator.SetBool("GO", true);
        }
        if (name == "fadeDone")
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHH!!!!");
            SceneManager.LoadScene("Main");
        }
    }
}
