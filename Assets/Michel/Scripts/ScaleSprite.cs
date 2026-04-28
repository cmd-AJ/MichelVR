using UnityEngine;

public class ScaleYOnly : MonoBehaviour
{
    public float targetY = 561.0027f;
    public float duration = 2f;

    private float timeElapsed = 0f;
    private Vector3 startScale;
    private Vector3 endScale;

    void Start()
    {
        startScale = transform.localScale;
        endScale = new Vector3(startScale.x, targetY, startScale.z);

        // Start from 0 on Y
        transform.localScale = new Vector3(startScale.x, 0f, startScale.z);
    }

    void Update()
    {
        if (timeElapsed < duration)
        {
            float t = Mathf.SmoothStep(0f, 1f, timeElapsed / duration);

            float newY = Mathf.Lerp(0f, targetY, t);
            transform.localScale = new Vector3(startScale.x, newY, startScale.z);

            timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.localScale = endScale;
        }
    }
}