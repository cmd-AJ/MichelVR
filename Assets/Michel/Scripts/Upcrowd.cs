using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    public float amplitude = 1f;   // How high it goes
    public float speed = 1f;       // How fast it moves

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);
    }
}

//