using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionGeneric : MonoBehaviour {

	public Text textUI;
	public string interactionMessage = "GENERIC";
	public bool isLooking = false;

	void Awake () 
	{
		textUI = GameObject.Find ("InteractionMessageText").GetComponent<Text> ();
		textUI.text = interactionMessage;
	}

	public void ShowInteractionMessage ()
	{


		isLooking = true;
		textUI.text = interactionMessage;
		textUI.enabled = true;
	}

	public virtual void Interaction ()
	{
		print ("Não era pra isso aparecer");
	}
}
