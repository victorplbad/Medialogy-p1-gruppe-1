using UnityEngine;
using UnityEngine.UI;

public class ColorFade : MonoBehaviour
{
    public Color startColor = Color.black;
    public Color endColor = Color.clear;
    public float time = 2.5f;
    public bool destroyAtEnd = true;

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
        if (destroyAtEnd && timer > 1) Destroy(this.gameObject);
    }
}
