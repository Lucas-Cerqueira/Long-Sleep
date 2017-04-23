using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionElevator : InteractionGeneric {
	private Vector3 endMarker;
	private Vector3 initialPosition;
	public float speed = 1.0f;
	private float startTime;
	private float journeyLength;
	private bool isGoingUp = false;
	private bool isGoingDown = false;
	public bool isDown = true;
	public GameObject elevator;

	// Use this for initialization
	void Start () {
		initialPosition = elevator.transform.position;
		endMarker = transform.GetChild (0).transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGoingUp) 
		{
			Vector3 objectPosition = Vector3.MoveTowards (elevator.transform.position, endMarker, speed);
			elevator.GetComponent<Rigidbody> ().MovePosition (objectPosition);
			if (Vector3.Distance(elevator.transform.position,endMarker) < 0.005f) 
			{
				isGoingUp = false;
				//isDown = false;
			}
		}

		if (isGoingDown)
		{
			Vector3 objectPosition = Vector3.MoveTowards (elevator.transform.position, initialPosition, speed);
			elevator.GetComponent<Rigidbody> ().MovePosition (objectPosition);
			if (Vector3.Distance(elevator.transform.position, initialPosition) < 0.005f) 
			{
				isGoingDown = false;
				isDown = true;
			}
		}

	}

	public override void Interaction ()
	{
		if (!isLocked) {
			if (isDown)
				isGoingUp = true;
			else
				isGoingDown = true;
		}
	}
		
}
