using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource boatAudio;
    public AudioSource UiAudio;
   // public AudioSource musicAudio;
    public AudioSource waterAudio;

    public AudioClip boatSound;
   // public AudioClip waveSound;
    public AudioClip seagullSound;
   // public AudioClip musicSound;
    public AudioClip waterSound;

    private Rigidbody rb;
    private CharacterScript c;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        c = GetComponent<CharacterScript>();

        waterAudio.clip = waterSound;
    }

    
    void Update()
    {
        float speed = rb.linearVelocity.magnitude * Time.timeScale;
        waterAudio.volume = Time.timeScale * 0.1f;
        if (!waterAudio.isPlaying) waterAudio.Play();

        boatAudio.volume = (speed / 200) + 0.15f;

        //Debug.Log("speed" + speed);
        if (speed > 5f && !boatAudio.isPlaying)
        {
            
            boatAudio.clip = boatSound;
            boatAudio.Play();
        }
        else if (speed <= 5f && boatAudio.isPlaying)
        {  
            boatAudio.Stop();
        }

        
    }

    public void PlaySound(AudioClip clip)
    {
        UiAudio.PlayOneShot(clip);    }
}
