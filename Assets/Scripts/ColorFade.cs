using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorFade : MonoBehaviour
{
    public Color startColor = Color.black;
    public Color endColor = Color.clear;
    public float fadeDuration = 2.5f;
    public bool destroyObjectAtEnd = false;

    private Image image;
    private TextMeshProUGUI text;           //Late addition to allow for fading buttons with text
    private float timer;

    void Start()
    {
        image = GetComponent<Image>();
        if (transform.childCount > 0) text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer += Mathf.Min(Time.unscaledDeltaTime, 0.05f) / fadeDuration;
        Color color = Color.Lerp(startColor, endColor, timer);

        if (image) image.color = color;
        if (text) text.color = new Color(0, 0, 0, color.a);

        if (destroyObjectAtEnd && timer > 1) Destroy(this.gameObject);  //Destroy host gameObject
        else if (timer > 1) Destroy(this);                              //Destroy only the script
    }
}
