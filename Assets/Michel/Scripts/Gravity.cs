using UnityEngine;

public class GlobalGravity : MonoBehaviour
{
    [Header("Gravity Settings")]
    public float gravityY = -5f;

    void Start()
    {
        Physics.gravity = new Vector3(0, gravityY, 0);
    }
}