using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;

    //[Header("Force")]
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
    public float soundDelay = 6f; // 👈 when the sound should play

    void Start()
    {
        InvokeRepeating("SpawnBall", startDelay, spawnInterval);
    }

    void SpawnBall()
    {
        GameObject ballInstance = Instantiate(ball, transform.position, ball.transform.rotation);

        float xpos = Random.Range(miniPos.position.x, maxPos.position.x);
        float ypos = Random.Range(miniPos.position.y, maxPos.position.y);
        float zpos = miniPos.position.z;

        force = Random.Range(miniForce, maxForce);

        Vector3 shootPos = new Vector3(xpos, ypos, zpos);
        Vector3 shoot = -(ballInstance.transform.position - shootPos).normalized;

        ballInstance.GetComponent<Rigidbody>().AddForce(shoot * force, ForceMode.Impulse);

        // ✅ Play sound after delay (instead of immediately)
        StartCoroutine(PlaySoundAfterDelay(ballInstance, soundDelay));

        // ✅ Destroy after X seconds
        Destroy(ballInstance, destroyTime);

        goles.rounds = goles.rounds - 1;
        Debug.Log("Rounds left: " + goles.rounds);

        if (goles.rounds == 0)
        {
            Debug.Log("No rounds left!");

            int halfRounds = Mathf.FloorToInt(goles.totalRounds / 2f);

            Debug.Log(goles.score - halfRounds);

            if (goles.score - halfRounds <= 0)
            {
                Debug.Log("Score condition met → GoToScoreScenePlay()");
                StartCoroutine(GoToScoreScenePlay());
            }
            else
            {
                Debug.Log("Score condition NOT met → GoToScoreScene()");
                StartCoroutine(GoToScoreScene());
            }
        }
    }

    IEnumerator PlaySoundAfterDelay(GameObject ballInstance, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (ballInstance != null) // make sure it still exists
        {
            AudioSource audio = ballInstance.GetComponent<AudioSource>();
            if (audio != null)
            {
                AudioSource.PlayClipAtPoint(goalClip, ballInstance.transform.position);
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
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator WaitBall()
    {
        yield return new WaitForSeconds(3f);
    }
}