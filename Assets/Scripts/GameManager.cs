using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer = 0f;
    public float debrisSec = 680.1f;
    public float debrisTotal = 0f;

    private readonly bool[] objectivesDone = new bool[9];
    public bool gameFinished = false;

    public CharacterScript character;
    public TextMeshProUGUI tmPro;
    private string initialText;

    private void Start()
    {
        initialText = tmPro.text;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;

        if (gameFinished)
        {
            tmPro.text = initialText.Replace("1", Round2Decimals(character.score)).Replace("2", Round2Decimals(debrisTotal));
        }
    }

    string Round2Decimals(float value)
    {
        return (Mathf.Round(value * 100) * 0.01f).ToString();
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

        if (done) // game end
        {
            debrisTotal = timer * debrisSec;
            Debug.Log(debrisTotal);

            // game end kode
        }
    }

    public GameObject endScreen;

    public void TrueEnding()
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
