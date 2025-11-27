using UnityEngine;
using UnityEngine.SceneManagement;

public class Animate : MonoBehaviour
{
    public Animator boatAnimator;
    public Animator fadeAnimator;
    public Animator textAnimator;
    public Animator buttonAnimator;

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
