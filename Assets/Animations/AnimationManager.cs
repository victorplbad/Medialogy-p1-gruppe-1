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
        Time.timeScale = 1.0f;
        debrisCounterScript.StartCounter(true);
        boatAnimator.SetBool("GO", true);
        textAnimator.SetBool("GO", true);
        buttonAnimator.SetBool("GO", true);
    }

    static int i;
    public void AnimationEvent(string name)
    {
        //print("AnimationEvent[" + i++ + "]: " + name);
        if (name == "boatDone")
        {
            fadeAnimator.SetBool("GO", true);
        }
        if (name == "fadeDone")
        {
            InfoScreen.SetActive(true);
        }
        if (name == "ChangeScene")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
