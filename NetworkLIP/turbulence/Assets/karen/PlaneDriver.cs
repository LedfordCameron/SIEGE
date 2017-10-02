using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDriver : MonoBehaviour {
	Animator anim;

	public float speed = 10.0f;
	public float rotationSpeed = 90.0f;
	public Rigidbody rb;
	Vector3 startPosition;
	Quaternion startRotation;
	Animation animotion;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		startPosition = transform.position;
		startRotation = transform.rotation;
		animotion = GetComponent<Animation> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		transform.Rotate (0, rotation, 0);

		//rb.AddForce (0.0f, 0.0f, 0);

		if (Input.GetKey (KeyCode.W) || Input.GetKey ("up")) {
			rb.AddForce (this.transform.forward * translation * 60.0f);
			//rb.AddForce (transform.position * translation * 1.0f);
			//Debug.Log(rb.velocity);
			//transform.Translate (0, 0, translation);
			//rb.AddForce (translation, 0.0f, 0);

		
		} else {
			rb.AddForce (this.transform.forward * .9f);
			rb.AddForce (0, -1.0f, 0);
		}
		//transform.Translate (0, 0, translation);
		
		//Debug.Log("rotation: "+ rotation);

		if (Input.GetKey ("space")) {
			anim.SetBool ("isThrusting", true);

			rb.AddForce (0, 200.0f, 0);
			//transform.Translate (0, 3.0f, 0);

		} else if (Input.GetKey(KeyCode.S)) {
			rb.AddForce (0, -200.0f, 0);

		} else {

			anim.SetBool ("isThrusting", false);
			rb.AddForce (0, -20.0f, 0);
		}

		if (rotation != 0) {
			anim.SetBool ("goStraight", false);
			this.transform.Rotate (0, rotation, 0);
			if (rotation < 0) {
				anim.SetBool ("turnLeft", true);
			} else {
				anim.SetBool ("turnRight", true);
			}
		} else {
			anim.SetBool ("goStraight", true);
			anim.SetBool ("turnLeft", false);
			anim.SetBool ("turnRight", false);
		}

		//if(rb.rotation > 
		//rb.AddForce (-5.0f, -5.0f, 0);
		//transform.Translate (0, -0.1f, 0);
	}

	public void resetPlane(){

		transform.position = startPosition;
		transform.rotation = startRotation;
		rb.velocity.Set (0, 0, 0);

	}

}
