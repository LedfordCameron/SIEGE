using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {
	

	Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		//ray = new Ray(transform.position,transform.forward);

	}

	void OnTriggerEnter(Collider other){
		Rigidbody otherRb = other.GetComponent<Rigidbody> ();

		if (otherRb.mass < rb.mass) {
			//other.GetComponent<Transform> ().rotation = Quaternion.LookRotation (transform.forward);
			otherRb.AddForce (transform.forward * 800.0f);
		}
	}
}
