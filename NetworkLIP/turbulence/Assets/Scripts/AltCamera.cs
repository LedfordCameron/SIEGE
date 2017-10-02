using UnityEngine;
using System.Collections;
using System;
public class AltCamera : MonoBehaviour
{
    public GameObject altCamera;
    public GameObject playerCamera;
    //public GameObject ballTarget;
    public float rotationSpeed = 20f;
    private GameObject ball;
   
    //public static event Action swap2main;

    private Quaternion lookRotation;
    private Vector3 direction;

    void Start()
    {
        ball = GameObject.Find("ball");
    }
    void Update()
    {
        //This places a blank gameobject that that follows the player (if the player is the assigned target)

            direction = (ball.transform.position - (new Vector3(transform.position.x, transform.position.y, transform.position.z))).normalized;
            lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
       // transform.position -= transform.forward - new Vector3(transform.position.x, transform.position.y, transform.position.z-10); //* Time.deltaTime ;
        if (Input.GetKeyUp("t"))
            {
            /*
            if(swap2main != null)
            {
                swap2main();
            }
            */
            playerCamera.SetActive(true);
            altCamera.SetActive(false);
            
            }
        }
    
}

