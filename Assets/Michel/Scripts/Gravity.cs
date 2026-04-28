using UnityEngine;

public class GlobalGravity : MonoBehaviour
{
    void Start()
    {
        Physics.gravity = new Vector3(0, -5f, 0);
    }
}//