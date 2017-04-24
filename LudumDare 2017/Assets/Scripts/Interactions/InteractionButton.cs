using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : InteractionGeneric {
	public GameObject interactionObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interaction ()
	{
		interactionObject.GetComponent<InteractionDownDoor> ().Interaction ();
	}
}
