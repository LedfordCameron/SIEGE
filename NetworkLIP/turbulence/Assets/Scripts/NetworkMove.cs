using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

//this is a class for passing player movement from players to the server
public class NetworkMove : MonoBehaviour {

	public SocketIOComponent socket;
	//public GameObject player;

	// Use this for initialization
	void Start () {
		//socket = gameObject.GetComponentInParent<SocketIOComponent> ();
	}

	void FixedUpdate(){
		//passes its position to the server

		if (gameObject.tag == "Player") {
			//Debug.Log("sending position to node: " + Network.VectorToJSON(gameObject.transform.position));
			socket.Emit ("move", Network.VectorToJSON (gameObject.transform.position));
		} else {
			socket.Emit ("moveBall", Network.VectorToJSON (gameObject.transform.position));
		}

	}


}
