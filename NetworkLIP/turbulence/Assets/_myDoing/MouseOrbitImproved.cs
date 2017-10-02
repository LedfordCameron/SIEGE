using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbitImproved : MonoBehaviour {

	public Transform target;
	public float distance ;
	public int rayDistance;

	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	public float distanceMin ;
	public float distanceMax ;

	private Rigidbody rigidbody;

	float x = 0.0f;
	float y = 0.0f;

	// Use this for initialization
	void Start () 
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		rigidbody = GetComponent<Rigidbody>();

		// Make the rigid body not change rotation
		if (rigidbody != null)
		{
			rigidbody.freezeRotation = true;
		}
	}

	void Update()
	{
		

	}

	void LateUpdate () 
	{

		Debug.DrawLine(target.position, transform.position, Color.green);

		if((Input.GetKey(KeyCode.A))|| (Input.GetKey(KeyCode.LeftArrow))){

			x -= 3; // the higher the number the faster the camera rotation
		}

		if((Input.GetKey(KeyCode.D))|| (Input.GetKey(KeyCode.RightArrow))){

			x += 3; // the higher the number the faster the camera rotation
		}



		if (target) 
		{
			x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);

			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);

			RaycastHit hit;
			if (Physics.Linecast (target.position, transform.position, out hit)) 
			{
				if(hit.distance > distanceMax){

					//Debug.Log("distance > 6 ");

					distance = distanceMax;
				}
				if(hit.distance < distanceMin)
				{
					distance = distanceMin ;
				}
				//}

				/*else
				{
					distance -=  hit.distance;
				}*/
				Debug.Log("distance " + distance);
				Debug.LogWarning("hit " + hit.distance + hit.transform.gameObject.tag);
			}
			else
			{
				distance = distanceMin;
			}
			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + target.position;

			transform.rotation = rotation;
			transform.position = position;
		}

		/*rayDistance = (int) BasicRaycast.theDistance;

		if(rayDistance > 6){

			Debug.Log("distance > 6 ");

			distance = 6;
		}
		if(rayDistance < 2)
		{
			distance = 2;
		}*/
		//Debug.dra

		//Debug.DrawLine(transform.position , target.transform.position, Color.cyan);

	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}