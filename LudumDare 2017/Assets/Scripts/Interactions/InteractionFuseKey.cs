using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFuseKey : InteractionGeneric {
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
			print ("Unlocked_Showing");
			transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = true;
			gameObject.tag = "Untagged";
		}
	}

}

