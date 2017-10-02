using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	public float speed = 1000.0f;
	public float minSpeed = 500.0f;
	public float rotSpeed = 500.0f;
	public float drag;

	private Rigidbody rb;
	public Vector3 oldVelocity;

	void Start () {
		//transform.Translate(Vector3.down * Time.deltaTime * velocity);

		rb = GetComponent<Rigidbody> ();
		rb.velocity = oldVelocity;

		//rb.AddForce(-transform.up * speed);
	}

	void FixedUpdate(){

		//oldVelocity = rb.velocity;
	//	Debug.Log (rb.velocity);

	}

	void OnCollisionEnter( Collision col){

		ContactPoint cp = col.contacts [0];

		rb.velocity = Vector3.Reflect (oldVelocity, cp.normal);
		rb.velocity += cp.normal * 2.0f;
	}

	/*
	void FixedUpdate () {


		//transform.Rotate (Vector3.up * Time.deltaTime * rotSpeed);


		Ray ray = new Ray(transform.position,transform.forward);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Time.deltaTime*speed + 0.1f)){
			Vector3 reflectDirection = Vector3.Reflect(ray.direction,hit.normal);
			float rot = 90 - Mathf.Atan2 (reflectDirection.z, reflectDirection.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3 (0, rot, 0);
			//transform.rotation = Quaternion.LookRotation(reflectDirection);
			rb.AddForce(reflectDirection * speed);
		}

		if(speed >minSpeed){
			speed -= drag;
		}


	//	this.transform.Translate(Vector3.forward*velocity*Time.deltaTime, this.transform);
	//	this.transform.Translate(Vector3.down*downForce);



	}

//	void OnTriggerEnter(Collider other){
//		//ContactPoint contact = collision.contacts;
		//	resetPlane();
//		Debug.Log ("hit");
//	}
*/
}
