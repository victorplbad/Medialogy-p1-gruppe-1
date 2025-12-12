using UnityEngine;
using UnityEngine.Playables;

public class TIMELINE : MonoBehaviour
{
    public PlayableDirector timelineToPlay;
    public double timeDuration;

    private void OnDestroy()
    {

        if (timelineToPlay != null)
        {
            timeDuration = timelineToPlay.duration;
            timelineToPlay.Play();
            Invoke(nameof(DonePlaying), (float)timeDuration);
        }
    }

   
    void DonePlaying()
    {
        Debug.Log("done");
    }
}

