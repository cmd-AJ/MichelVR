using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //public Transform target;
    //public float force;
    //public float shootDelay = 2;
    public float destroyTime = 10f;


    // Start is called before the first frame update
    void Start()
    {
     //   Destroy(gameObject, destroyTime);
        //  Invoke("Shoot", shootDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void Shoot() 
    //{
    //   Vector3 shoot= (transform.position - this.target.position).normalized;
    //   GetComponent<Rigidbody>().AddForce(shoot*force,ForceMode.Impulse);
    //}
}
