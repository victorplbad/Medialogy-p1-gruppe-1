using UnityEngine;

public class Animate : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /**if (animator.playbackTime)
        {

        }*/
    }

    public void PlayAnimation()
    {
        animator.SetBool("GO", true);
    }
}
