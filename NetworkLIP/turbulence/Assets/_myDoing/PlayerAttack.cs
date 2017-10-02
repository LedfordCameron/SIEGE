using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;
	//public float attackTimer;
	//public float coolDown;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider enemy)
	{
		target = enemy.gameObject;

		print(target.name);

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			Attack();
	   }
	}

	//melee only
	private void Attack(){
		print(" we are attacking");
		float distance = Vector3.Distance(target.transform.position, transform.position);

		// makes sure the enemy is in front of the player
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);
		//behind = - , front = + , side = 0


		//makes sure the enemy is close
		if(distance >5f) {
			if(direction > 0){
				//EnemyHealth E_health=  (EnemyHealth)target.GetComponent("EnemyHealth");
				target.GetComponent<EnemyHealth>().AdjustCurrentHealth(-1);
				print("we attacked");
			}
		}
		target.GetComponent<EnemyHealth>().AdjustCurrentHealth(-1);
	}
}
