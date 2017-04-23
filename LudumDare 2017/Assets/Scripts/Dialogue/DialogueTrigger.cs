using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public string dialogueSituation;

	private bool triggeredDialogue = false;

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") 
		{
			if (!triggeredDialogue) 
			{
				GameObject.Find("Dialogue").GetComponent<DialogueHandler>().SetDialogueSituation(dialogueSituation);
				triggeredDialogue = true;
			}
		}
	}
}
