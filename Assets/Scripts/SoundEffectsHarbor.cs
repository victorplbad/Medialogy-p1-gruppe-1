using UnityEngine;

public class SoundEffectsHarbor : MonoBehaviour
{
    public AudioSource boatAudio;
    public AudioSource UiAudio;
    public AudioSource musicAudio;
    public AudioSource waterAudio;

    public AudioClip boatSound;
    public AudioClip waveSound;
    public AudioClip seagullSound;
    public AudioClip musicSound;
    public AudioClip waterSound;

    void Start()
    {
        waterAudio.clip = waterSound;
        waterAudio.volume = 0.1f;
    }

    private void Update()
    {
        if (!waterAudio.isPlaying) waterAudio.Play();
    }

    public void PlayMusicWithDelay()
    {
        Invoke("PlayMusic", 6f);
    }
        

    public void PlayMusic()
    {
       // Debug.Log("test");
        //musicAudio.PlayOneShot(musicSound);
        musicAudio.clip = musicSound;
        musicAudio.Play();
    }
}
