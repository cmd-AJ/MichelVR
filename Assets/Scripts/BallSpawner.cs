using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;

    private float force;
    public float miniForce;
    public float maxForce;

    public Goal goles;

    public float startDelay = 2f;
    public float spawnInterval = 10f;

    public Transform miniPos;
    public Transform maxPos;

    public float shootDelay = 4f;
    public int Rounds;

    public AudioClip goalClip;

    [Header("Scene Settings")]
    public int sceneToLoad = 1;

    public float destroyTime = 10f;

    [Header("Audio")]
    public float soundDelay = 6f;

    [Header("Indicators")]
    public GameObject[] indicators;

    void Start()
    {
        goles = Goal.goaaal;

        if (goles == null)
        {
            Debug.LogError("Goal singleton not found!");
            return;
        }

        // Hide all indicators at start


        goles.ResetGameStats(Rounds);

        Debug.Log("BallSpawner initialized in scene: " + gameObject.scene.name);

        InvokeRepeating(nameof(SpawnBall), startDelay, spawnInterval);
    }

    void SpawnBall()
    {
        Debug.Log("=== SpawnBall CALLED ===");

        // New ball = hide all indicators
        SetIndicators(false);

        GameObject ballInstance = Instantiate(
            ball,
            transform.position,
            ball.transform.rotation
        );

        float xpos = Random.Range(miniPos.position.x, maxPos.position.x);
        float ypos = Random.Range(miniPos.position.y, maxPos.position.y);
        float zpos = miniPos.position.z;

        force = Random.Range(miniForce, maxForce);

        Vector3 shootPos = new Vector3(xpos, ypos, zpos);
        Vector3 shootDirection =
            -(ballInstance.transform.position - shootPos).normalized;

        Rigidbody rb = ballInstance.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(shootDirection * force, ForceMode.Impulse);
        }

        StartCoroutine(PlaySoundAfterDelay(ballInstance, soundDelay));

        StartCoroutine(DestroyBall(ballInstance));

        goles.rounds--;

        if (goles.rounds == 0)
        {
            int halfRounds = Mathf.FloorToInt(goles.totalRounds / 2f);
            int result = goles.score - halfRounds;

            if (result <= 0)
            {
                goles.totalRounds = Rounds;
                goles.score = 0;

                StartCoroutine(GoToScoreScenePlay());
            }
            else
            {
                StartCoroutine(GoToScoreScene());
            }
        }
    }

    IEnumerator DestroyBall(GameObject ballInstance)
    {
        yield return new WaitForSeconds(destroyTime);

        // Ball destroyed = show ALL indicators
        SetIndicators(true);

        if (ballInstance != null)
        {
            Destroy(ballInstance);
        }
    }

    void SetIndicators(bool state)
    {
        foreach (GameObject indicator in indicators)
        {
            if (indicator != null)
            {
                indicator.SetActive(state);
            }
        }
    }

    IEnumerator PlaySoundAfterDelay(GameObject ballInstance, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (ballInstance != null)
        {
            AudioSource audio = ballInstance.GetComponent<AudioSource>();

            if (audio != null)
            {
                AudioSource.PlayClipAtPoint(
                    goalClip,
                    ballInstance.transform.position
                );
            }
        }
    }

    IEnumerator GoToScoreScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }

    IEnumerator GoToScoreScenePlay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}