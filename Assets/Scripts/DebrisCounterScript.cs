using UnityEngine;
using TMPro;

public class DebrisCounterScript : MonoBehaviour
{
    public int trashPerSecond = 700;
    private int currentTrash = 0;
    private bool counting = false;
    private float timer = 0f;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "0";
    }

    void Update()
    {
        if (!counting) return;

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            currentTrash += trashPerSecond;
            textMesh.text = currentTrash.ToString() + " kg";
            timer = 0f;
        }
    }

    public void StartCounter(bool start)
    {
        counting = true;
    }
}