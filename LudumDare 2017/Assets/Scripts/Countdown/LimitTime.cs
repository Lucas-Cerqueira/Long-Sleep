using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitTime : MonoBehaviour {
	
	public float limitTime = 600.0f;
	private float targetTime;

	private Text countdownText;

	void Start () 
	{
		countdownText = GetComponent<Text> ();

		StartCountdown ();
	}
	

	void Update () 
	{
		float remainingTime = targetTime - Time.time;
		if (remainingTime >= 0)
			countdownText.text = string.Format ("{0:#00}:{1:00}", Mathf.Floor (remainingTime/60), Mathf.Floor (remainingTime%60));

		if (Mathf.Floor (remainingTime%60) <= 0)
			print ("Acabou o tempo");
	}

	public void StartCountdown()
	{
		targetTime = Time.time + limitTime;
	}
}
