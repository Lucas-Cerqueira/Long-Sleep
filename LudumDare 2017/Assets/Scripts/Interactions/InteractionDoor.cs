using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoor : InteractionGeneric {
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
		RaycastHit[] hit;
		bool isPlayer = false;
		Vector3 dwn = transform.TransformDirection(Vector3.down);

		hit = Physics.SphereCastAll(initialPosition, 1, transform.forward, 1);
		for (int i = 0; i < hit.GetLength (0); i++)
			if (hit [i].transform.tag == "Player")
				isPlayer = true;
//		print ("Door " + Time.time-actualTime + isDown + isPlayer);
		if (Time.time >= actualTime && !isDown && !isPlayer)
			CloseDoors ();
	}

	public override void Interaction ()
	{
		if (!isLocked) {
			for (int i = 0; i < transform.childCount; i++) {
				transform.GetChild (i).GetComponent<OpenDoor> ().OpenDoors ();
			}
			actualTime = Time.time + closeTime; 
			isDown = false;
			//transform.GetComponent<Collider> ().enabled = false;
		}
	}

	public void CloseDoors()
	{
		OpenDoor[] close = GetComponentsInChildren<OpenDoor> ();
		for (int i = 0; i < close.Length; i++)
			close [i].CloseDoors ();
	}

	public void setInitialPosition ()
	{
		OpenDoor[] local = GetComponentsInChildren<OpenDoor> ();
		for (int i = 0; i < local.Length; i++)
			local [i].setInitialPosition ();
	}
}
