using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    void Start()
    {
        Rigidbody rigidbody = gameObject.GetComponent("Rigidbody") as Rigidbody;
        rigidbody.velocity = transform.forward * speed;
    }
}
