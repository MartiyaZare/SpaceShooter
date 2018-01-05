using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;

	// Use this for initialization
	void Start () {
        Rigidbody rigidbody = gameObject.GetComponent("Rigidbody") as Rigidbody;
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
}
