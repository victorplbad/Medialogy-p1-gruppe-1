using UnityEngine;
using UnityEngine.Playables;

public class TIMELINE : MonoBehaviour
{
    public PlayableDirector timelineToPlay;

    private void OnDestroy()
    {
        if (timelineToPlay != null)
        {
            timelineToPlay.Play();
        }
    }
}

