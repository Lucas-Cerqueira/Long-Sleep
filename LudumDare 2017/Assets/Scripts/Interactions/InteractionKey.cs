using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionKey : InteractionGeneric {
	public GameObject keyPointer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interaction ()
	{
		keyPointer.GetComponent<InteractionDoor> ().Unlock ();
		print ("Unlocked");
		gameObject.SetActive (false);
	}
}
