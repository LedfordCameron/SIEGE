using UnityEngine;
using System.Collections;

public class spinAirplane : MonoBehaviour {
    public GameObject airplane;
    public float speed = 30f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
