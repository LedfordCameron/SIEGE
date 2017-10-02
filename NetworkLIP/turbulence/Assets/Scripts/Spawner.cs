using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject myPlayer;
	public GameObject networkPlayer;
	public GameObject theBall;

	private bool ballspawned = false;

	Dictionary<string, GameObject> players = new Dictionary<string, GameObject> ();
	Dictionary<string, GameObject> balls = new Dictionary<string, GameObject> ();

	public GameObject SpawnPlayer(string id){
		//look at the old code in network manager to have them spawn on a spawn point
		var player = Instantiate (networkPlayer);

		//adding new player to dictionary
		players.Add (id, player);
		return player;
	}

	//this puts the ball into the game it is only called at the start of the game or after a point reset
	public GameObject SpawnBall(){
		//look at the old code in network manager to have them spawn on a spawn point
		if (ballspawned == true) {
			Debug.Log ("The ball has already been spawned");
			return balls["ball"];
		} else {
			var ball = Instantiate (theBall);
			balls.Add ("ball", ball);
			ballspawned = true;
			Debug.Log ("Ball has been spawned");
			return ball;
		}

	} 
		
	//retruns the id of the player
	public GameObject FindPlayer(string id){
		return players [id];
	}

	//returns the location of the ball
	public GameObject FindBall(){
		return balls["ball"];
	}

	//takes the ball out of hte game
	public void RemoveBall(){
		var ball = balls ["ball"];
		balls.Remove ("ball");
		Destroy (ball);
		ballspawned = false;
	}

	//removes a player based on the id given
	public void Remove(string id){
		var player = players [id];
		players.Remove (id);
		Destroy (player);
	}
}
