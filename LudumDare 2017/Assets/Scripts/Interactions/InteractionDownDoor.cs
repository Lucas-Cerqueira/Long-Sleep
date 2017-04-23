using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class InteractionDownDoor : InteractionGeneric {
	private Vector3 endMarker;
	private Vector3 initialPosition;
	public AudioClip openSound;
	public AudioClip closeSound;
	public float speed = 1.0f;
	public float closeTime = 100.0f;
	public string situation = "";
	private float actualTime;
	private float journeyLength;
	private bool isGoingUp = false;
	private bool isGoingDown = false;
	private bool isDown = true;

	private AudioSource audioSource;

	private bool triggeredDialogue = false;

	// Use this for initialization
	void Start () {

		initialPosition = transform.position;
		endMarker = transform.GetChild (0).transform.position;
		audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (isLocked)
			interactionMessage = "This door is locked";
		else
			interactionMessage = "Press \"E\" to open";

		RaycastHit[] hit;
		bool isPlayer = false;
		Vector3 dwn = transform.TransformDirection(Vector3.down);
		if (isGoingUp) 
		{
			transform.position = Vector3.MoveTowards (transform.position, endMarker, speed);
			if (Vector3.Distance(transform.position,endMarker) < 0.005f) 
			{
				isGoingUp = false;
				isDown = false;
				actualTime = Time.time + closeTime; 
			}
		}

		if (isGoingDown)
		{
			transform.position = Vector3.MoveTowards (transform.position, initialPosition, speed);
			if (Vector3.Distance(transform.position, initialPosition) < 0.005f) 
			{
				isGoingDown = false;
				isDown = true;
			}
		}
			
		hit = Physics.SphereCastAll(initialPosition, 1, transform.forward, 1);
		for (int i = 0; i < hit.GetLength (0); i++)
			if (hit [i].transform.tag == "Player")
				isPlayer = true;
		if (Time.time >= actualTime && !isDown && !isPlayer)
			CloseDoors ();
	}

	public override void Interaction ()
	{
        if (!triggeredDialogue && !situation.Equals(""))
        {
            GameObject.Find("Dialogue").GetComponent<DialogueHandler>().SetDialogueSituation(situation);
            triggeredDialogue = true;
        }

		if (!isLocked) {
			if (isDown)
			{
				isGoingUp = true;
				if (openSound && !audioSource.isPlaying) 
				{
					audioSource.clip = openSound;
					audioSource.Play ();
				}
			} 
			else
			{
				isGoingDown = true;
				if (closeSound) 
				{
					audioSource.clip = closeSound;
					audioSource.Play ();
				}
			}
		}
	}

	public void CloseDoors ()
	{
		isGoingDown = true;
		if (closeSound && !audioSource.isPlaying) 
		{
			audioSource.clip = closeSound;
			audioSource.Play ();
			print ("Deu play");
		}
	}

	public void setInitialPosition()
	{
		initialPosition = transform.position;
	}

	public Vector3 getInitialPosition()
	{
		return initialPosition;
	}
		
}
