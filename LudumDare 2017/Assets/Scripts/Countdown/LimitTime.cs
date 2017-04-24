using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LimitTime : MonoBehaviour {

	public string gameOverSceneName = "gameOver";
	public float limitTime = 600.0f;
	private float targetTime;
	private bool count = false;
	private TMPro.TMP_Text countdownText;
	private float stopTime = 0;

	void Start () 
	{
		countdownText = GetComponent<TMP_Text> ();

		RestartCountdown ();
	}
	

	void Update ()
	{
		if (count) 
		{
			float remainingTime = targetTime - Time.time;
			if (remainingTime >= 0)
				countdownText.SetText (string.Format ("{0:#00}:{1:00}", Mathf.Floor (remainingTime / 60), Mathf.Floor (remainingTime % 60)));

			if (Mathf.Floor (remainingTime / 60) == 0 && Mathf.Floor (remainingTime % 60) <= 0) 
			{
				GameObject.Find ("FadeInOutPanel").GetComponent<FadeInOut> ().FadeIn ();
				StartCoroutine ("GameOver", GameObject.Find ("FadeInOutPanel").GetComponent<FadeInOut> ().fadeOutTime);
			}
		}
	}

	IEnumerator GameOver(float time)
	{
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (gameOverSceneName);
	}


	public void RestartCountdown()
	{
		targetTime = Time.time + limitTime;
		count = true;
	}

	public void StartCountdown()
	{
		count = true;
		targetTime += Time.time - stopTime;
	}

	public void StopCountdown()
	{
		stopTime = Time.time;
		count = false;
	}
}
