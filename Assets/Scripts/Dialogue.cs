using UnityEngine;
using TMPro;
using System.Collections;
using System.Data;
using UnityEditor.Rendering;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI TextComponet;

    [TextArea(3,10)]
    public  string[] lines;
    public float TextSpeed;

    public Animator animator;

    private int index;
    //private const string HTML_Alpha = "<color=00000000>";
    //private const float MAX_TYPE_TIME = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextComponet.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(TextComponet.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                TextComponet.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        animator.SetBool("IsOpen", true);

        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        //type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            TextComponet.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    //her prøvede jeg det som viktor gerne ville have texten ikke hoppede ned på næste linje
/*    private IEnumerator TypeLine(string p)
    {
       isTyping = true;
        Dialogue.TextComponet.text = "";

        string originalText = p;
        string displayedText = "";
        int alphaIndex = 0;

        foreach (char c in p.ToCharArray())
        {
            alphaIndex++;
            DialogText.text = originalText;

            diplayedText = DialogText.Insert(alphaIndex, HTML_Alpha);
            DialogText.text = displayedText;

            yield return new WaitForSeconds(MAX_TYPE_TIME / TextSpeed);
        }

        isTyping = false;
    }
*/

    void NextLine()
    {
        if (index < lines.Length)
        {
            index++;
            TextComponet.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void EndDialogue()
    {
            animator.SetBool("IsOpen", false);
    }
}
