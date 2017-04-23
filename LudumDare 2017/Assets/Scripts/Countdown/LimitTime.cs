using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LimitTime : MonoBehaviour {
	
	public float limitTime = 600.0f;
	private float targetTime;

	private TMPro.TMP_Text countdownText;

	void Start () 
	{
		countdownText = GetComponent<TMP_Text> ();

		StartCountdown ();
	}
	

	void Update () 
	{
		float remainingTime = targetTime - Time.time;
		if (remainingTime >= 0)
			countdownText.SetText (string.Format ("{0:#00}:{1:00}", Mathf.Floor (remainingTime/60), Mathf.Floor (remainingTime%60)));

		if (Mathf.Floor (remainingTime/60) == 0 && Mathf.Floor (remainingTime%60) <= 0)
			print ("Acabou o tempo");
	}

	public void StartCountdown()
	{
		targetTime = Time.time + limitTime;
	}
}
