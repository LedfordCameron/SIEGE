using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFlight : MonoBehaviour {

	// maybe put a raycast on the tip of the plane to decide whether it should explode when hitting the wall or another 
	//player
	/// <summary>
	/// spacebar pull up
	/// mecham rot
	/// </summary>

	public float speed = 25.0f;
	public Rigidbody rb;
	Vector3 lastForwardDir;
	Vector3 startPosition;
	Quaternion startRotation;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		lastForwardDir = transform.forward;

		startPosition = transform.position;
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float bias = 0.95f;

		speed -= transform.forward.y * Time.deltaTime * 25.0f;
		if (speed < 25.0f) {
			speed = 25.0f;
		}

		if (speed > 50.0f) {
			//Debug.Log("too fast");
			resetPlane ();

		}


		if (lastForwardDir.y > transform.forward.y) {
			rb.AddForce (transform.forward * Time.deltaTime * speed * 2, ForceMode.VelocityChange);
			Debug.Log("too fast");
			//transform.position += transform.forward * Time.deltaTime * speed;
		} else if (lastForwardDir.y < transform.forward.y) {
			rb.AddForce (transform.forward * Time.deltaTime * speed * 20, ForceMode.Acceleration);
			//transform.position += transform.forward * Time.deltaTime * speed;
		} else {
			transform.position += transform.forward * Time.deltaTime * speed;
		}


		transform.Rotate (Mathf.Clamp(Input.GetAxis ("Vertical"), -65.0f, 65.0f), Input.GetAxis ("Horizontal")*1.5f, 0.0f);
		//Input.GetAxis ("Horizontal")* Input.GetAxis ("Vertical")); //

		//Mathf.Clamp( (Input.GetAxis ("Vertical") * Input.GetAxis ("Horizontal")),-65.0f , 65.0f)

		//transform.rotation.x += Mathf.Clamp (transform.rotation.x, -65.0f, 65.0f);
		//transform.rotation.y += Mathf.Clamp (transform.rotation.y, -65.0f, 65.0f);
		//transform.rotation.z += Mathf.Clamp (transform.rotation.z, -65.0f, 65.0f);

		lastForwardDir= transform.forward;
	}


	void resetPlane(){

		transform.position = startPosition;
		transform.rotation = startRotation;
		speed = 25.0f;

	}

}
 