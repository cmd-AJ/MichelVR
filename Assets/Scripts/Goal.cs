using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Game Stats")]
    public int score;
    public int rounds;
    public int totalRounds;

    public int cpuScore;

    [Header("Audio")]
    public AudioSource goalSound;

    public static Goal goaaal;

    private void Awake()
    {
        // Singleton setup
        if (goaaal != null && goaaal != this)
        {
            Destroy(gameObject);
            return;
        }

        goaaal = this;
        DontDestroyOnLoad(gameObject);

    }

    /// <summary>
    /// Call this every time a new scene starts
    /// to reset score and setup new rounds.
    /// </summary>
    public void ResetGameStats(int newRounds)
    {
        score = 0;
        rounds = newRounds;
        totalRounds = newRounds;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;

            if (goalSound != null)
            {
                goalSound.Play();
            }

            Destroy(other.gameObject);
        }
        else
        {
            cpuScore++;
        }
    }
}