using UnityEngine;
using UnityEngine.UI;

public class ColorFade : MonoBehaviour
{
    public Color startColor = Color.black;
    public Color endColor = Color.clear;
    public float time = 2.5f;
    public bool destroyObjectAtEnd = true;

    private Image image;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / time;

        image.color = Color.Lerp(startColor, endColor, timer);
        if (destroyObjectAtEnd && timer > 1) Destroy(this.gameObject);  //Destroy host gameObject
        else if (timer > 1) Destroy(this);                              //Destroy only the script
    }
}
