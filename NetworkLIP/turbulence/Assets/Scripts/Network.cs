using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

//***********These are all the actions that take place on the client side. Every callback is sent when a 
//laptop connects to the node server on this mac, moves while connected, or disconnects*****************
public class Network : MonoBehaviour {

	static SocketIOComponent socket;

	public GameObject waitingToLoadCamera;
	//private Vector3 playerPos;

	public Spawner spawner;

	public GameObject myplayer;

	public GameObject myBall;

	private int playersInGame;

	//private bool ballIsSpawned = false;

	// Use this for initialization
	void Start () {
		//playerPos = planePlayer.transform.position;
		playersInGame = 0;
		socket = GetComponent<SocketIOComponent> ();
		socket.On ("open", OnConnected);
		//socket.On ("enable", OnEnabled);
		socket.On ("spawn", OnSpawned);
		socket.On("spawnBall", OnBallSpawned);
		socket.On ("move", OnMoved);
		//socket.On ("rot", OnRot);
		socket.On("moveBall", OnBallMoved);
		socket.On ("disconnected", OnDisconnected);
		socket.On ("requestPosition", OnRequestPosition);
		socket.On("requestBallPosition", OnBallRequestPosition);
		socket.On ("updatePosition", OnUpdatePosition);
		socket.On("updateBallPosition", OnUpdateBallPosition);

		waitingToLoadCamera.SetActive (false);
		//socket.On ("registered", OnRegistered);

	}

	void FixedUpdate(){
		//passes myplayers position to the server
		//Debug.Log("sending position to node: " + VectorToJSON(myplayer.transform.position));
		if (myplayer != null) {
			socket.Emit ("move", VectorToJSON(myplayer.transform.position));
		}

		if (myBall != null) {
			socket.Emit("moveBall", VectorToJSON(myBall.transform.position));
		}
	}

	//this is a callback for on connected.
	void OnConnected (SocketIOEvent e) {
		Debug.Log ("connected");
		playersInGame++;
		Debug.Log ("There are " + playersInGame + " players in the game.");
	}

	void OnEnabled(SocketIOEvent e){
		Debug.Log ("enabled my player");
		//planePlayer.SetActive (true);
		waitingToLoadCamera.SetActive (false);
	}

	//callback for when a player is spawned
	void OnSpawned (SocketIOEvent e){
		Debug.Log ("spawned" + e.data);
		var player = spawner.SpawnPlayer(e.data ["id"].ToString());
		//this is a catch to make sure the position exist before we move the player there.
		if (e.data ["x"]) {
			//if there are synch issues start here.
			var movePos = GetVectorFromJSON (e);
		}

	}

	void OnBallSpawned (SocketIOEvent e){
		//if (ballIsSpawned == false) {
			Debug.Log ("spawned" + e.data);
			var ball = spawner.SpawnBall ();
			//ballIsSpawned = true;
			//this is a catch to make sure the position exist before we move the player there.
			if (e.data ["x"]) {
				//if there are synch issues start here.
				var movePos = GetVectorFromJSON (e);
			}

		//} else {
			//Debug.Log ("Can't spawn a ball that has already spawned");
		//}

	}

	//callback for when a player moves, sends their movement data to the server
	void OnMoved(SocketIOEvent e){
		//waitingToLoadCamera.SetActive (false);
		Debug.Log ("networkplayer is moving" + e.data);

		var pos = GetVectorFromJSON (e);

		var player = spawner.FindPlayer(e.data ["id"].ToString());

		player.transform.position = pos;

	}

	/*void OnRot(SocketIOEvent e){
		//Debug.Log ("networkplayer is moving" + e.data);

		var rot = GetRotFromJSON (e);

		var player = spawner.FindPlayer(e.data ["id"].ToString());

		player.transform.rotation = rot;
	}*/

	void OnBallMoved(SocketIOEvent e){
		//waitingToLoadCamera.SetActive (false);
		Debug.Log ("ball is moving" + e.data);

		var pos = GetVectorFromJSON (e);

		var theBall = spawner.FindBall ();

		theBall.transform.position = pos;

	}
		
	void OnRegistered(SocketIOEvent e){
		Debug.Log ("registered id: " + e.data);
	}

	//asks where the already connected players are *there will always be atleast one
	void OnRequestPosition(SocketIOEvent e){
		Debug.Log ("server is requestion position");
		socket.Emit ("updatePosition", Network.VectorToJSON(myplayer.transform.position));
	}

	void OnBallRequestPosition(SocketIOEvent e){
		Debug.Log ("server is requesting ball position");
		socket.Emit ("updateBallPosition", Network.VectorToJSON(myBall.transform.position));
	}
		
	//updates the positions of the players already in game once the client connects.
	void OnUpdatePosition(SocketIOEvent e){
		Debug.Log ("updating position: " + e.data);
		var pos = GetVectorFromJSON (e);

		var player = spawner.FindPlayer(e.data ["id"].ToString());

		player.transform.position = pos;
	}

	void OnUpdateBallPosition(SocketIOEvent e){
		Debug.Log ("updating ball position: " + e.data);
		var pos = GetVectorFromJSON (e);

		var ball = spawner.FindBall();

		ball.transform.position = pos;
	}

	//on disconnect it removes the player from the dictionary, and destroys them.
	void OnDisconnected(SocketIOEvent e){
		Debug.Log ("player disconnected: " + e.data);
		var id = e.data ["id"].ToString ();
		spawner.Remove (id);
		spawner.RemoveBall ();
	}

	public static Vector3 GetVectorFromJSON(SocketIOEvent e){
		return new Vector3 (e.data ["x"].n, e.data ["y"].n, e.data ["z"].n);
	}

	public static JSONObject VectorToJSON(Vector3 vector){
		JSONObject j = new JSONObject (JSONObject.Type.OBJECT);
		j.AddField ("x", vector.x);
		j.AddField ("y", vector.y);
		j.AddField ("z", vector.z);
		return j;
	}

	/*public static Quaternion GetRotFromJSON(SocketIOEvent e){
		return new Quaternion (e.data ["rotx"].n, e.data ["roty"].n, e.data ["rotz"].n);
	}

	public static JSONObject QuaterianToJSON(Quaternion rot){
		JSONObject j = new JSONObject (JSONObject.Type.OBJECT);
		j.AddField ("rotx", rot.x);
		j.AddField ("roty", rot.y);
		j.AddField ("rotz", rot.z);
		return j;
	}*/

	//you may need this for player collisions
	public static JSONObject PlayerIDToJSON(string id){
		JSONObject j = new JSONObject (JSONObject.Type.OBJECT);
		j.AddField ("id", id);
		return j;
	}


}

