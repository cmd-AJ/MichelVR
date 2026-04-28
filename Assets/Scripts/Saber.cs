using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    private Vector3 previousPos;
    private AudioSource audioSource;
    int x;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 120) 
            {
                Debug.Log(x++);
                audioSource.Play();
                Destroy(hit.transform.gameObject);
            }
        }
        previousPos = transform.position;
    }
}
