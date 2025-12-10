using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SoundEffectsHarbor : MonoBehaviour
{
    public AudioSource boatAudio;
    public AudioSource musicAudio;
    public AudioSource waterAudio;
    public AudioSource seagullAudio;
    public AudioSource boatHornAudio;

    public AudioClip seagullSound;
    public AudioClip musicSound;
    public AudioClip waterSound;
    public AudioClip boatSound;
    public AudioClip boatHornSound;

    void Start()
    {
        waterAudio.clip = waterSound;
        waterAudio.volume = 0.1f;

        StartCoroutine(PlaySeagullRandomly());
    }

    private void Update()
    {
        if (!waterAudio.isPlaying) waterAudio.Play();

        if (Input.GetKeyDown(KeyCode.P)) SceneManager.LoadScene("Main");
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    IEnumerator PlaySeagullRandomly()
    {
        while (true)
        {
            float delay = Random.Range(5f, 20f);
            yield return new WaitForSeconds(delay);

            seagullAudio.PlayOneShot(seagullSound);
        }
    }

    public void PlayMusicWithDelay()
    {
        Invoke("PlayMusic", 6f);
    }
        

    public void PlayMusic()
    {
        musicAudio.clip = musicSound;
        musicAudio.Play();
    }
        
    public void PlayBoatAndHorn()
    {
        boatAudio.volume = 0.4f;
        boatAudio.PlayOneShot(boatSound);

        boatHornAudio.volume = 0.15f;
        boatHornAudio.PlayOneShot(boatHornSound);
    }
}

