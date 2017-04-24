using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : DialogueText {

	public float timePerChar = 0.25f;

	private TMPro.TMP_Text text;

	private string situation;

	private int currentIndex = 0;
	private bool showingDialogue = false;
	private bool finished = false;
	private float startTime;

	// Use this for initialization
	void Start () 
	{
		text = GetComponent<TMPro.TMP_Text> ();
		situation = "wakeUp";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!finished && !showingDialogue && currentIndex < dialoguesList [situation].Length)
		{
			startTime = Time.time;
			showingDialogue = true;
			text.enabled = true;
			text.SetText (dialoguesList [situation] [currentIndex]);
		}

		else if (showingDialogue && (Time.time - startTime) >= timePerChar * dialoguesList [situation] [currentIndex].Length) 
		{
			showingDialogue = false;
			text.enabled = false;
			currentIndex++;
		}
		else if (currentIndex == dialoguesList [situation].Length)
			finished = true;

	}

	public void SetDialogueSituation (string s)
	{
		situation = s;
		currentIndex = 0;
		finished = false;
		showingDialogue = false;
	}

	public void waitSetDialogueSituation (float duration, string s)
	{
		StartCoroutine(WaitForDialog(duration,s));
	}

	IEnumerator WaitForDialog(float duration, string s)
	{
		yield return new WaitForSeconds(duration);   //Wait
		situation = s;
		currentIndex = 0;
		finished = false;
		showingDialogue = false;
	} 
}
