using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionKey : InteractionGeneric {
	public GameObject keyPointer;

	// Use this for initialization
	void Start () {
		interactionMessage = "Press \"E\" to pick it up";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interaction ()
	{
		if (!isLocked) {
			keyPointer.GetComponent<InteractionGeneric> ().Unlock ();
			print ("Unlocked");
			gameObject.SetActive (false);
		}
	}
		
}
