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

    public float startDelay = 2;
    public float spawnInterval = 10f;

    public Transform miniPos;
    public Transform maxPos;

    public float shootDelay = 4;
    public int Rounds;

    public int destroyTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBall()
    {

        GameObject ballInstance = Instantiate(ball, transform.position, ball.transform.rotation);
        StartCoroutine(WaitBall());
        float xpos = Random.Range(miniPos.position.x, maxPos.position.x);
        float ypos = Random.Range(miniPos.position.y, maxPos.position.y);
        float zpos = miniPos.position.z;
        force = Random.Range(miniForce, maxForce);
        Vector3 shootPos = new Vector3(xpos, ypos, zpos);
        Vector3 shoot = -(ballInstance.transform.position - shootPos).normalized;
        ballInstance.GetComponent<Rigidbody>().AddForce(shoot * force, ForceMode.Impulse);
        Destroy(ballInstance, destroyTime);


        goles.rounds = goles.rounds - 1;
        if (goles.rounds == 0)
        {
            StartCoroutine(GoToScoreScene());
        }


    }


    IEnumerator GoToScoreScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
    IEnumerator WaitBall()
    {
        yield return new WaitForSeconds(3);
    }

}
//