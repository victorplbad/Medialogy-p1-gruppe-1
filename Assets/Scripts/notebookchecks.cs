using UnityEngine;

public class notebookchecks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject checkbox;
    public GameObject starbox;

    public bool rightAnswer = false;

    public void ButtonPress(bool correct)
    {
        starbox.SetActive(correct);

        checkbox.SetActive(true);
    }
}
