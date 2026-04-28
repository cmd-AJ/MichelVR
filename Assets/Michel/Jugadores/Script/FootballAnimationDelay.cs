using UnityEngine;
using System.Collections;

public class CustomDelayLoop : MonoBehaviour
{
    public Animator animator;

    public float[] delays = { 3.7f, 4.2f, 5.1f, 3.9f }; // your custom times

    private int index = 0;

    void Start()
    {
        StartCoroutine(LoopRoutine());
    }

    IEnumerator LoopRoutine()
    {
        while (true)
        {
            // Get current delay
            float currentDelay = delays[index];

            yield return new WaitForSeconds(currentDelay);

            animator.SetTrigger("StartLoop");

            // Move to next delay
            index++;

            // Loop back if we reach the end
            if (index >= delays.Length)
                index = 0;
        }
    }
}