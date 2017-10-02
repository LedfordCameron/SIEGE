using UnityEngine;
using System.Collections;
using System;
public class CameraAssist : MonoBehaviour
{
    public GameObject assistPosition;
    public GameObject mainCamera;
    //public GameObject ballTarget;
    public float rotationSpeed = 20f;
    //public static event Action swap2main;

    private Quaternion lookRotation;
    private Vector3 direction;
    private GameObject ball;

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
        
    }

}

