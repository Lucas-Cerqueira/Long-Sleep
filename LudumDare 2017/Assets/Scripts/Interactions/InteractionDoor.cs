using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoor : InteractionGeneric {
	public bool isLocked = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interaction ()
	{
		if (!isLocked) {
			for (int i = 0; i < transform.childCount; i++) {
				transform.GetChild (i).GetComponent<OpenDoor> ().OpenDoors ();
			}
			//transform.GetComponent<Collider> ().enabled = false;
		}
	}

	public void Unlock ()
	{
		isLocked = false;
	}
}
