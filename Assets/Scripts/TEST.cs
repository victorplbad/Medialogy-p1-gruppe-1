using Unity.VisualScripting;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public ColorFade fader;
    public GameObject go;

    // Update is called once per frame
    void Update()
    {
        go.SetActive(fader.IsDestroyed());
    }
}
