using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

	//class variables
	//public GameObject waitingToLoadCamera;
	//private GameObject myPlayer;
	//public bool offlinemode;
	//private int numPlayersInLobby;
	//public int maxCapacity;

	//public Text timerText;
	//public float timer;
	//private bool matchStart;
	//public Text redScore;
	//public Text blueScore;

	//private int bScore;
	//private int rScore;

	//an array of spawn points
	SpawnPoint[] spawnPoints;

	//notifications
	//public static event Action plusOne;
	//public static event Action startmatch;

	// Use this for initialization
	void Start () {
		spawnPoints = GameObject.FindObjectsOfType<SpawnPoint> ();
		//waitingToLoadCamera.SetActive (false);
		//timerText.text = timer.ToString ("f0");
		//matchStart = false;
		//rScore = 0;
		//bScore = 0;
		//blueScore.text = "Blue Score: " + bScore.ToString ();
		//redScore.text = "Red Score: " + rScore.ToString ();

		//subscriptions
		//GameController.GoBabyGo += EnableMyPlayer;
	}

	void FixedUpdate(){


	}

}

