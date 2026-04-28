using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreMenu : MonoBehaviour
{
    public TMP_Text yourScore, pcScore;
    public int pcNewScore;
    public int newRounds;
    // Start is called before the first frame update
    void Start()
    {
        if (Goal.goaaal != null)
        {
            //rounds for callculations
            newRounds = Goal.goaaal.rounds;
            pcNewScore = Goal.goaaal.score;

            //your Score=Rounds-goals
            yourScore.text = "" + (Goal.goaaal.totalRounds - pcNewScore);
            pcScore.text = "" + pcNewScore;
        }
    }


    public void MainMenuButton()
    {
        Destroy(Goal.goaaal);
        SceneManager.LoadScene(0);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
