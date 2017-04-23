using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionControlRoom : InteractionGeneric {
	public GameObject keyPointer;

	// Use this for initialization
	void Start () {
		interactionMessage = "Press \"E\" to interact";
	}

	// Update is called once per frame
	void Update () {

	}

	public override void Interaction ()
	{
		if (!isLocked) 
		{
			GameObject.Find("Dialogue").GetComponent<DialogueHandler>().SetDialogueSituation("afterOpeningEscapePodRoom");
			keyPointer.GetComponent<InteractionGeneric> ().Unlock ();
			print ("Unlocked");
			gameObject.tag = "Untagged";
		}
	}

}
