using UnityEngine;

public class AnimationMessenger : MonoBehaviour
{
    public void AnimationEvent(string name)
    {
        GameObject.FindAnyObjectByType<AnimationManager>().AnimationEvent(name);
    }
}