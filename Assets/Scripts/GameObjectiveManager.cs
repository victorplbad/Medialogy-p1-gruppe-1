using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectiveManager : MonoBehaviour
{
    public CharacterScript character;
    public GameObject endScreen;
    public TextMeshProUGUI endScreenText;

    public float debrisSec = 680.1f;
    public float debrisTotal = 0f;
    public bool gameFinished = false;

    
    private string initialText;
    private float timer = 0f;
    private readonly bool[] objectivesDone = new bool[9];   //we have 8 objectives + the debug one(takes index 0)

    private void Start()
    {
        initialText = endScreenText.text;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;

        if (gameFinished)
        {
            string newText = initialText;
            newText = newText.Replace("AAAB", character.score.ToString("F2"));
            newText = newText.Replace("AAAC", debrisTotal.ToString("F2"));
            newText = newText.Replace("AAAD", (debrisTotal * 0.3).ToString("F2"));
            endScreenText.text = newText;
        }
    }

    public void CompletedObjective(int ID)
    {
        objectivesDone[ID] = true;

        bool done = true;
        for (int i = 1; i < objectivesDone.Length; i++)
        {
            if (!objectivesDone[i])
            {
                done = false;
            }
        }
        gameFinished = done;

        if (done)
        {   // game end
            debrisTotal = timer * debrisSec;
            Debug.Log(debrisTotal);
        }
    }

    public void EndCheck()
    {
        if (!gameFinished) return;

        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ExtraTrueEnd()
    {
        SceneManager.LoadScene("harbor");
    }
}
