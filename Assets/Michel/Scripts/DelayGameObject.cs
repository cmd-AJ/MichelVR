using UnityEngine;
using System.Collections;

public class EnableAfterDelay : MonoBehaviour
{
    public GameObject target;
    public float delay = 2f;

    void Start()
    {
        if (target != null)
            target.SetActive(false); // optional: ensure it's off at start

        StartCoroutine(EnableObject());
    }

    IEnumerator EnableObject()
    {
        yield return new WaitForSeconds(delay);

        if (target != null)
            target.SetActive(true);
    }
}