using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private Goal goles;
    private TMP_Text scoreText;

    [Header("True = Player | False = CPU")]
    public bool isPlayer = true;

    void Awake()
    {
        // Gets the TMP component from this same object
        scoreText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        // Gets your DontDestroyOnLoad singleton
        goles = Goal.goaaal;
    }

    void Update()
    {
        if (goles == null) return;

        int value = isPlayer
            ? goles.score
            : goles.totalRounds - goles.score;

        // 00, 01, 02...
        scoreText.text = value.ToString("00");
    }
}