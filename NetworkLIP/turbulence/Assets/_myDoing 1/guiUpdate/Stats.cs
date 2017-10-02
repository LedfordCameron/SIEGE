using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Stats  {

	[SerializeField]
	private BarScript bar;

	[SerializeField]
	private float maxValue;

	[SerializeField]
	private float currentValue;

	public float CurrentValue {
		get {
			return currentValue;
		}

		set
		{
			this.currentValue = Mathf.Clamp(value, 0, MaxValue);		
			bar.Value= this.currentValue;

		}
	}

	public float MaxValue {
		get 
		{
			return maxValue;
		}

		set 
		{
			maxValue = value;
			bar.MaxValue = maxValue;
		}
	}

	public void Initialize()
	{
		this.MaxValue= maxValue;
		this.CurrentValue= currentValue;
	}


}