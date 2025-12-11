using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundEffects : MonoBehaviour
{
    public AudioSource boatAudio;
    public AudioSource UiAudio;
    public AudioSource musicAudio;
    public AudioSource waterAudio;
    public AudioSource ambientAudio;

    public AudioClip boatSound;
    public AudioClip seagullSound;
    public AudioClip musicSound;
    public AudioClip waterSound;

    private Rigidbody rb;
    private CharacterScript c;

    void Start()
    {
        Application.targetFrameRate = 60;

        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        c = GetComponent<CharacterScript>();

        waterAudio.clip = waterSound;
        ambientAudio.clip = seagullSound;

        StartCoroutine(PlaySeagullRandomly());
    }

    void Update()
    {
        float speed = rb.linearVelocity.magnitude * Time.timeScale;
        waterAudio.volume = Time.timeScale * 0.1f;
        if (!waterAudio.isPlaying) waterAudio.Play();

        boatAudio.volume = (speed / 200) + 0.1f;

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

        if (Input.GetKeyDown(KeyCode.P)) SceneManager.LoadScene("harbor");
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    public void PlayMusic()
    {
        musicAudio.clip = musicSound;
        musicAudio.Play();
    }

    IEnumerator PlaySeagullRandomly()
    {
        while (true)
        {
            float delay = Random.Range(30f, 60f) + seagullSound.length;
            yield return new WaitForSeconds(delay);

            ambientAudio.PlayOneShot(seagullSound);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        UiAudio.PlayOneShot(clip);    
    }
}
