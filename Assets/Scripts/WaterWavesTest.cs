using UnityEngine;

public class WaterWavesTest : MonoBehaviour
{
    public float speedX = 0.1f;
    public float speedY = 0.0f;

    public float waveAmplitude = 0.02f;
    public float waveFrequency = 2f;
    public float waveSpeed = 1f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    
    void Update()
    {
        float baseX = Time.time * speedX;
        float baseY = Time.time * speedY;

        float waveX = Mathf.Sin(baseY * waveFrequency + Time.time * waveSpeed) * waveAmplitude;
        float waveY = Mathf.Sin(baseX * waveFrequency + Time.time * waveSpeed) * waveAmplitude;

        rend.material.mainTextureOffset = new Vector2(baseX + waveX, baseY + waveY);
    }
}
