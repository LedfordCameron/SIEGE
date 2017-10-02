using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 10;
	public int curHealth = 10;

	public float healthBarLength;

	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width/2;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		GUI.Box(new Rect( 10,40,healthBarLength, 20), "Enemy : "+ curHealth+ "/" + maxHealth);
	}


	public void AdjustCurrentHealth(int add){
		curHealth += add;
		if (curHealth <0)
			curHealth = 0;
		if (curHealth > maxHealth)
			curHealth= maxHealth;
		if (maxHealth<1)
			maxHealth= 1;


		healthBarLength = (Screen.width / 2)* (curHealth / (float)maxHealth);
		print("took damage");
		if(curHealth == 0)
		{
			Destroy(gameObject);
			
		}
	}

}
