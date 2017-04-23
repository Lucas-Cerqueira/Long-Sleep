using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDownDoor : InteractionGeneric {
	private Vector3 endMarker;
	private Vector3 initialPosition;
	public float speed = 1.0f;
	public float closeTime = 100.0f;
	public string situation = "";
	private float actualTime;
	private float journeyLength;
	private bool isGoingUp = false;
	private bool isGoingDown = false;
	private bool isDown = true;

	private bool triggeredDialogue = false;

	// Use this for initialization
	void Start () {

		initialPosition = transform.position;
		endMarker = transform.GetChild (0).transform.position;
	}

	// Update is called once per frame
	void Update () {
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
				isGoingUp = true;
			else
				isGoingDown = true;
		}
	}

	public void CloseDoors (){
		isGoingDown = true;
	}
		
		
}
