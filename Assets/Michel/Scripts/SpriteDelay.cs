using System.Collections;
using UnityEngine;

public class SpriteFadeOut : MonoBehaviour
{
    [Header("Fade Settings")]
    public float delay = 1f;
    public float fadeDuration = 1.5f;

    [Header("Audio")]
    public AudioSource audioSource; // assign in Inspector

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        // wait before starting fade
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        Color startColor = sr.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

            sr.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            yield return null;
        }

        // ensure fully transparent
        sr.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        // play sound (if assigned)
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }

        // disable object
        gameObject.SetActive(false);
    }
}