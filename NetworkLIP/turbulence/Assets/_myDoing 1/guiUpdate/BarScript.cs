using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText;

	public float MaxValue { get; set;}

	public float Value
	{
		set{

			string[] temp= valueText.text.Split(':');
			valueText.text = temp[0] + ": " + value;
			fillAmount = Map(value, 0, MaxValue, 0, 1);
			Debug.Log("value " + value);
		}

	}

	// Use this for initialization
	void Start () 
	{
		Value = 100;

	}
	
	// Update is called once per frame
	void Update () {

		AdjustBar();
	
	}
	//content.image.fillamount

	void AdjustBar()
	{

		if (fillAmount != content.fillAmount)
		{
			
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime *lerpSpeed);

		}
	}

	private float Map(float value, float inMin, float outMin, float inMax, float outMax)
	{
		return (value - inMin) * (outMax - outMin)/ (inMax - inMin) + outMin;

	}

}
