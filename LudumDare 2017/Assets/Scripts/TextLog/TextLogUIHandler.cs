using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextLogUIHandler : MonoBehaviour {

	private Image image;
	private GameObject text;
	private bool enabled = false;
	private string activeLog;
	private string activeGameObjectName;
	private bool triggeredDialogue = false;

	// Use this for initialization
	void Start () 
	{
		image = GetComponent<Image> ();
		text = transform.GetChild (0).gameObject;
	}
	
	public void Enable (string situation, string message, string gameObjectName)
	{
		image.enabled = true;
		text.SetActive (true);
		text.GetComponent<TMP_Text> ().SetText (message);
		enabled = true;
		activeLog = situation;

		GameObject.Find ("Timer").GetComponent<LimitTime> ().StopCountdown ();
		GameObject.Find ("FPSPlayer").GetComponent<FPSMovement> ().enabled = false;
	}

	public void Disable (string gameObjectName)
	{
		image.enabled = false;
		text.SetActive (false);
		enabled = false;

		GameObject.Find("Dialogue").GetComponent<DialogueHandler>().SetDialogueSituation(activeLog);
		GameObject.Find ("Timer").GetComponent<LimitTime> ().StartCountdown ();

		GameObject.Find ("FPSPlayer").GetComponent<FPSMovement> ().enabled = true;
	}

	void Update ()
	{
		if (enabled && (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.E) || Input.GetMouseButtonDown (0)))
			Disable (activeGameObjectName);
			
	}
}
