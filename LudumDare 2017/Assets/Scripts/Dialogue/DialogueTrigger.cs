using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public string dialogueSituation;
	public float procDuration = 2.0f;
	public bool waitForActivating = false;
	public float waitTimeActivating = 2.0f;

	private bool triggeredDialogue = false;
	private float startTime = 0.0f;

	void OnTriggerEnter(Collider other) 
	{
		if (!waitForActivating) {
			if (other.tag == "Player") {
				StartCoroutine (WaitForTrigger (procDuration));
			}
		}
	}

	void OnTriggerStay (Collider other) 
	{
		if (waitForActivating) {
			if (other.tag == "Player") {
				print ("Comecou a esperar");
				if (startTime<=0.0f) {
					startTime = Time.time;
				}
				if (Time.time - startTime >= waitTimeActivating) {
					if (!triggeredDialogue) 
					{
						print ("Vai exibir o dialogo porque passou o tempo de espera");
						GameObject.Find("Dialogue").GetComponent<DialogueHandler>().SetDialogueSituation(dialogueSituation);
						triggeredDialogue = true;
					}
				}
			}
		}
	}

	void OnTriggerExit (Collider other) 
	{
		if (other.tag == "Player") {
			startTime = 0.0f;
		}
	}

	IEnumerator WaitForTrigger(float duration)
	{
		yield return new WaitForSeconds(duration);   //Wait
		if (!triggeredDialogue) 
		{
			GameObject.Find("Dialogue").GetComponent<DialogueHandler>().SetDialogueSituation(dialogueSituation);
			triggeredDialogue = true;
		}
	} 
}
