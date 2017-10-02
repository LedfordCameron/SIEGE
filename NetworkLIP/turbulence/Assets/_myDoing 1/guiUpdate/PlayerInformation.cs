using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public enum PlayerStatus {GOTATTACKED, ATTACKING, BLOCKING, NORMAL};

[RequireComponent(typeof(Animator))]

public class PlayerInformation : MonoBehaviour
{

	public PlayerStatus playerStatus;

	[SerializeField]
	private Stats health;

	private Animator animator;


	private void Awake()
	{
		health.Initialize();
		animator = GetComponent<Animator>();
	}


	
	// Update is called once per frame
	void Update ()
	{


		//#########DEBUG KEYS############
		/*if (Input.GetKeyDown(KeyCode.Q))
		{
			health.CurrentValue -=10;
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			health.CurrentValue +=10;
		}*/

		if(health.CurrentValue <= 0)
		{
			animator.Play("Death");
		}
	}
}