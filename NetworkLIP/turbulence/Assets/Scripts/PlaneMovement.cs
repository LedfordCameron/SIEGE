using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {

	public float boost = 50.0f;
	public float speed = 20.0f;
    public bool altView = false;
    //8=================D~~~~

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        speed += transform.forward.y * Time.deltaTime * 10f;
        if (speed < 35f)
        {
            speed = 35f;
        }

        if (altView == false)
        {
            if (Input.GetKeyDown("space"))
            {
                transform.position -= transform.forward * Time.deltaTime * boost;
                print("I wanna go fast");
            }
            else
            {
                transform.position -= transform.forward * Time.deltaTime * speed;
                transform.Rotate(-Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));
                //print ("go slow");
            }
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                transform.position -= transform.forward * Time.deltaTime * boost;
                print("I wanna go fast");
            }
            else
            {
                transform.position -= transform.forward * Time.deltaTime * speed;
                transform.Rotate(-Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));
                //print ("go slow");
            }
        }


        if (Input.GetKeyUp("t"))
        {
            altView = false;   
        }
        if (Input.GetKeyDown("t"))
        {
            altView = true;
        }
        
    }
}
