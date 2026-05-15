using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreUI : MonoBehaviour
{
    private Goal goles;
    private TMP_Text scoreText;

    [Header("True = Player | False = CPU")]
    public bool isPlayer = true;

    public float textDelay = 3f;

    private int lastValue = -999;
    private Coroutine updateRoutine;

    void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        goles = Goal.goaaal;
    }

    void Update()
    {
        if (goles == null) return;

        int value = isPlayer
            ? goles.score
            : goles.cpuScore - goles.score;

        // Only trigger if value changed
        if (value != lastValue)
        {
            lastValue = value;

            if (updateRoutine != null)
                StopCoroutine(updateRoutine);

            updateRoutine = StartCoroutine(UpdateTextDelayed(value));
        }
    }

    IEnumerator UpdateTextDelayed(int value)
    {
        yield return new WaitForSeconds(textDelay);

        scoreText.text = value.ToString("00");
    }
}