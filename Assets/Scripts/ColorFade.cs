using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorFade : MonoBehaviour
{
    public Color startColor = Color.black;
    public Color endColor = Color.clear;
    public float time = 2.5f;
    public bool destroyObjectAtEnd = true;

    private Image image;
    private TextMeshProUGUI text;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        if (transform.childCount > 0) text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime / time;
        Color color = Color.Lerp(startColor, endColor, timer);

        if (image) image.color = color;
        if (text) text.color = new Color(0, 0, 0, color.a);

        if (destroyObjectAtEnd && timer > 1) Destroy(this.gameObject);  //Destroy host gameObject
        else if (timer > 1) Destroy(this);                              //Destroy only the script
    }
}
