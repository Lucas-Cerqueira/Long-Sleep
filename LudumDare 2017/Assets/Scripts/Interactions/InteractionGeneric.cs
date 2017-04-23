using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionGeneric : MonoBehaviour {

	[HideInInspector] public TMPro.TMP_Text textUI;
	public string interactionMessage = "GENERIC";

	void Awake () 
	{
		textUI = GameObject.Find ("InteractionMessageText").GetComponent<TMPro.TMP_Text> ();
		textUI.SetText(interactionMessage);
	}

	public void ShowInteractionMessage ()
	{
		textUI.SetText(interactionMessage);
		textUI.enabled = true;
	}

	public virtual void Interaction ()
	{
		print ("Não era pra isso aparecer");
	}
}
