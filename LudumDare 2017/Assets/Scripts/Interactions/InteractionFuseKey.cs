using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFuseKey : InteractionGeneric {
	public GameObject keyPointer;

	// Use this for initialization
	void Start () 
	{
		interactionMessage = "You need a fuse";
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
			GameObject.Find("Dialogue").GetComponent<DialogueHandler>().SetDialogueSituation("afterFixingFuse");
		}
	}

	public override void Unlock ()
	{
		base.Unlock ();
		interactionMessage = "Press \"E\" to place the fuse";
	}

}

