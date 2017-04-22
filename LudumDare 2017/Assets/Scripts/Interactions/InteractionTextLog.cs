using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTextLog : InteractionGeneric {

	private TextLogUIHandler textLogUIHandler;

	// Use this for initialization
	void Start () 
	{
		textLogUIHandler = GameObject.Find ("TextLogUI").GetComponent<TextLogUIHandler>();
	}
		

	public override void Interaction ()
	{
		textLogUIHandler.Enable ();
	}
}
