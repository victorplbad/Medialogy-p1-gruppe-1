using UnityEngine;

public class notebookchecks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject checkbox;
    public GameObject starbox;

    public bool rightAnswer = false;


    public void Right(bool correct)
    {
        rightAnswer = correct;

    }


    public void ButtonPress()
    {


        if (rightAnswer == true)
        {

            starbox.SetActive(true);

        }

        checkbox.SetActive(true);
        Time.timeScale = 1f;

    }


}
