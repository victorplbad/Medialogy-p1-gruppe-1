using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource inGameAudio;
    public AudioSource UiAudio;
    public AudioSource musicAudio;

    public AudioClip boatSound;
    public AudioClip waveSound;
    public AudioClip seagullSound;
    public AudioClip musicSound;

    private Rigidbody rb;
    private CharacterScript c;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c = GetComponent<CharacterScript>();
    }

    
    void Update()
    {
        float speed = rb.linearVelocity.magnitude * Time.timeScale;

        inGameAudio.volume = (speed / 150) + 0.1f;

        Debug.Log("speed" + speed);
        if (speed > 5f && !inGameAudio.isPlaying)
        {
            //Debug.Log("boatMove");
            inGameAudio.clip = boatSound;
            inGameAudio.Play();
        }
        else if (speed <= 5f && inGameAudio.isPlaying)
        {  
            inGameAudio.Stop();
        }
        
    
    }
}
