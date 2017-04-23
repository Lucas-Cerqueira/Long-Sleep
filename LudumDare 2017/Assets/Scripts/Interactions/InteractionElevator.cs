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
	private bool isWaiting = false;

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
				InteractionElevator[] interactions = elevator.GetComponentsInChildren<InteractionElevator> ();
				for (int i = 0; i < interactions.Length; i++)
					interactions [i].setIsDown (true);
				isDown = false;
				elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().setInitialPosition ();
				elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().setInitialPosition ();
				realLockLeft = upLockLeft;
				realLockRight = upLockRight;
				elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().isLocked = realLockLeft;
				elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().isLocked = realLockRight;
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
				elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().setInitialPosition ();
				elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().setInitialPosition ();
				realLockLeft = dwnLockLeft;
				realLockRight = dwnLockRight;
				elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().isLocked = realLockLeft;
				elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().isLocked = realLockRight;
			}
		}

		if (lockDoors) {
			InteractionGeneric[] locking = elevator.GetComponentsInChildren<InteractionGeneric> ();
			for (int i = 0; i < 2; i++)
				locking [i].isLocked = true;
		}

		if (isWaiting) Interaction();
	}

	public override void Interaction ()
	{
		print ("TCHAU" + isLocked + isDown);
		if (!isLocked && isDown) {
			print ("OI");
			elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().CloseDoors ();
			elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().CloseDoors ();
			if (Vector3.Distance (elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().transform.position,
				       elevator.transform.GetChild (0).GetComponent<InteractionDownDoor> ().getInitialPosition ()) >0.1f) {
				isWaiting = true;
				return;
			}
			if (Vector3.Distance (elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().transform.position,
				       elevator.transform.GetChild (1).GetComponent<InteractionDownDoor> ().getInitialPosition ()) > 0.1f) {
				isWaiting = true;
				return;
			}
			isWaiting = false;
			if (isDown)
				isGoingUp = true;
//			else
//				isGoingDown = true;

		}

	}

	public void setIsDown (bool setup)
	{
		isDown = setup;
	}
		
}
