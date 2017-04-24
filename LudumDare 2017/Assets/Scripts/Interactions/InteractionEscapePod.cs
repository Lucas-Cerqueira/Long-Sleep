using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionEscapePod : InteractionGeneric {

	public float ignitionTime = 2f;
	public float leavingTime = 2f;
	public float flyingTime = 3f;
	public float leavingSpeed = 10f;
	public float finalSpeed = 100f;
	public string gameOverSceneName = "gameOver";

	private bool playerInside = false;
	private bool isLeaving = false;
	private bool isFlying = false;
	private float elapsedTime;

	// Use this for initialization
	void Start () 
	{
		interactionMessage = "Press \"E\" to enter";
	}


	void Update ()
	{
		if (playerInside && !isLeaving) 
		{
			if (elapsedTime < ignitionTime)
				elapsedTime += Time.deltaTime;
			else
			{
				isLeaving = true;
				elapsedTime = 0;
			}
		}

		if (playerInside && isLeaving && !isFlying) 
		{
			if (elapsedTime < leavingTime) 
			{
				elapsedTime += Time.deltaTime;
				transform.Translate (transform.right * leavingSpeed * Time.deltaTime);
			}
			else 
			{
				transform.Translate (transform.right * finalSpeed * Time.deltaTime);
				isFlying = true;
				elapsedTime = 0;
			}
		}

		if (playerInside && isFlying) 
		{
			if (elapsedTime < flyingTime) 
			{
				elapsedTime += Time.deltaTime;
				transform.Translate (transform.right * finalSpeed * Time.deltaTime);
			}
			else
			{
				GameObject.Find ("FadeInOutPanel").GetComponent<FadeInOut> ().FadeIn ();
				StartCoroutine ("GameOver", GameObject.Find ("FadeInOutPanel").GetComponent<FadeInOut> ().fadeOutTime);
				//SceneManager.LoadScene (gameOverSceneName);
			}
		}
			
	}

	IEnumerator GameOver(float time)
	{
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (gameOverSceneName);
	}

	public override void Interaction ()
	{
		GameObject player = GameObject.Find ("FPSPlayer");
		player.GetComponent<CapsuleCollider> ().enabled = false;
		player.GetComponent<Rigidbody> ().isKinematic = true;

		player.transform.GetChild (0).GetComponent<MouseLook> ().horizontalClamp = 40;
		player.transform.GetChild (0).GetComponent<MouseLook> ().verticalClamp = 40;

		player.transform.position = transform.GetChild (0).position;
		player.transform.rotation = transform.GetChild (0).rotation;

		player.transform.SetParent (this.transform);

		GameObject.Find ("EscapeDoor").GetComponent<OpenEscapeDoor> ().Open ();
		GameObject.Find ("Escape_Pod1_Window").GetComponent<ClosePodWindow> ().Close ();

		GameObject.Find("Dialogue").GetComponent<DialogueHandler>().SetDialogueSituation("insideEscapePod");

		elapsedTime = 0;
	}

	public void SetPlayerInside (bool state)
	{
		playerInside = state;
	}



}
