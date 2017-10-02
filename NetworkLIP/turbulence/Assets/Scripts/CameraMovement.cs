using UnityEngine;
using System.Collections;
using System;
public class CameraMovement : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject altCamera;
    public GameObject followTarget;
    public GameObject resetCamera;
    private Vector3 targetPosition;

	public int distanceFromTarget;
    //public GameObject ballTarget;
    public float moveSpeed;
    public bool triggered = false;
    public float rotationSpeed = 20f;
    //public static event Action swap2alt;
    private Quaternion lookRotation;
    private Vector3 direction;

    void Update() { 
   
		targetPosition = new Vector3(followTarget.transform.position.x , followTarget.transform.position.y , followTarget.transform.position.z - 20);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown("t"))
        {
            /*
            if (swap2alt != null)
            {
                swap2alt();
            }*/
            altCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
    }
}

