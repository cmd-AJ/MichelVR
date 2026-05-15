using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Game Stats")]
    public int score;
    public int rounds;
    public int totalRounds;

    [Header("Audio")]
    public AudioSource goalSound;

    public static Goal goaaal;

    private void Awake()
    {
        // Singleton setup
        if (goaaal != null && goaaal != this)
        {
            Debug.Log("Duplicate Goal found. Destroying: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        goaaal = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("Goal singleton created: " + gameObject.name);
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

        Debug.Log("=== Goal Reset ===");
        Debug.Log("Score reset to: " + score);
        Debug.Log("Rounds set to: " + rounds);
        Debug.Log("Total rounds set to: " + totalRounds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;

            Debug.Log("Goal scored! Current score: " + score);

            if (goalSound != null)
            {
                goalSound.Play();
            }

            Destroy(other.gameObject);
        }
    }
}