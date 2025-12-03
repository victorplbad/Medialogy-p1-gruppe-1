using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationManager : MonoBehaviour
{
    public Animator boatAnimator;
    public Animator fadeAnimator;
    public Animator textAnimator;
    public Animator buttonAnimator;
    public GameObject InfoScreen;
    public DebrisCounterScript debrisCounterScript;

    public void PlayAnimation()
    {
        debrisCounterScript.StartCounter(true);
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
            InfoScreen.SetActive(true);
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHH!!!!");
        }
        if (name == "ChangeScene")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
