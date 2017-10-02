using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//declarations
	public int scoreRed;
	public int scoreBlue;
	//public int maxScore = 2;
	public int countdownnum;
	public bool gameOver = false;
	//public GameObject redVictory;
	//public GameObject blueVictory;
	public GameObject ball;
	public GameObject redGoal;
	public GameObject blueGoal;
	public GameObject nm;
	public Text redScore;
	public Text blueScore;
	public Text timer;
	public float time;


	//ui
	public Text countDown;


	//notifications
	//public static event Action GoBabyGo;

	// Use this for initialization
	void Start () {
		scoreRed = 0;
		redScore.text = "Red Score: " + scoreRed;
		scoreBlue = 0;
		blueScore.text = "Blue Score: " + scoreBlue;
		time = 600;
		timer.text = time.ToString("f0");

		//numPlayersInLobby = 0;

	}


	// Update is called once per frame
	void FixedUpdate () {
		if (scoreRed == 5)
		{
			//redVictory.SetActive(true);
			StartCoroutine(backToMenu());
		}
		if (scoreBlue == 5)
		{
			//blueVictory.SetActive(true);
			StartCoroutine(backToMenu());
		}

		time -= Time.deltaTime;
		timer.text = time.ToString("f0");
		if (time <= 0)
		{
			time = 0;
			StartCoroutine(backToMenu());
		}
	}

	public IEnumerator backToMenu()
	{
		countDown.gameObject.SetActive(true);

		if (scoreBlue > scoreRed)
		{
			countDown.text = "Blue team wins!";
		}else if (scoreBlue < scoreRed)
		{
			countDown.text = "Red team wins!";
		}
		else
		{
			countDown.text = "Tie game!";
		}
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("Main Menu");
	}


	void OnEnable()
	{
		ScoreRed.pointRed += pointRed;
		ScoreBlue.pointBlue += pointBlue;
	}

	void OnDisable()
	{
		ScoreRed.pointRed -= pointRed;
		ScoreBlue.pointBlue -= pointBlue;
	}

	public void pointRed()
	{
		scoreRed = scoreRed + 1;
		redScore.text = "Red Score: " + scoreRed;
	}

	public void pointBlue()
	{
		scoreBlue++;
		blueScore.text = "Blue Score: " + scoreBlue;
	}

}