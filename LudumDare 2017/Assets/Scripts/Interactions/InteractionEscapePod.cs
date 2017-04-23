using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEscapePod : InteractionGeneric {

	public float ignitionTime = 2f;
	public float leavingTime = 2f;
	public float leavingSpeed = 10f;
	public float finalSpeed = 100f;

	private bool playerInside = false;
	private bool isLeaving = false;
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

		if (isLeaving) 
		{
			if (elapsedTime < leavingTime) 
			{
				elapsedTime += Time.deltaTime;
				transform.Translate (transform.right * leavingSpeed * Time.deltaTime);
			}
			else
				transform.Translate (transform.right * finalSpeed * Time.deltaTime);
		}
			
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
