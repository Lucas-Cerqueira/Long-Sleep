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
	private bool lockDoors = false;
	public bool upLockRight = false;
	public bool upLockLeft = false;
	public bool dwnLockRight = false;
	public bool dwnLockLeft = false;
	private bool realLockRight = false;
	private bool realLockLeft = false;

	// Use this for initialization
	void Start () {
		initialPosition = elevator.transform.position;
		endMarker = transform.GetChild (0).transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGoingUp) 
		{
			lockDoors = true;
			Vector3 objectPosition = Vector3.MoveTowards (elevator.transform.position, endMarker, speed);
			elevator.GetComponent<Rigidbody> ().MovePosition (objectPosition);
			if (Vector3.Distance(elevator.transform.position,endMarker) < 0.005f) 
			{
				isGoingUp = false;
				lockDoors = false;
				elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().setInitialPosition ();
				elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().setInitialPosition ();
//				realLockLeft = upLockLeft;
//				realLockRight = upLockRight;
//				realLockRight = lockRight;
//				realLockLeft = lockLeft;
				//isDown = false;
			}
		}

		if (isGoingDown)
		{
			lockDoors = true;
			Vector3 objectPosition = Vector3.MoveTowards (elevator.transform.position, initialPosition, speed);
			elevator.GetComponent<Rigidbody> ().MovePosition (objectPosition);
			if (Vector3.Distance(elevator.transform.position, initialPosition) < 0.005f) 
			{
				lockDoors = false;
				isGoingDown = false;
				isDown = true;
			}
		}

		if (lockDoors) {
			InteractionGeneric[] locking = elevator.GetComponentsInChildren<InteractionGeneric> ();
			for (int i = 0; i < locking.GetLength (0); i++)
				locking [i].isLocked = true;
//		}
		} else if(isGoingUp || isGoingDown) {
			if (Vector3.Distance (elevator.transform.position, initialPosition) < 2) {
				realLockLeft = upLockLeft;
				realLockRight = upLockRight;
			} else {
				realLockLeft = dwnLockLeft;
				realLockRight = dwnLockRight;
			}
		}

	}

	public override void Interaction ()
	{
		if (!isLocked) {
			elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().CloseDoors ();
			elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().CloseDoors ();
			if (isDown)
				isGoingUp = true;
			else
				isGoingDown = true;

		}

	}
		
}
