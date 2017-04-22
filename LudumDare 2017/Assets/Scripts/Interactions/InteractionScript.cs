using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : InteractionGeneric {


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		Debug.DrawRay (transform.position, fwd * 3, Color.red);

		if (Physics.Raycast (transform.position, fwd, out hit, 3, Physics.AllLayers, QueryTriggerInteraction.Collide))
		{
			if (hit.transform.tag == "Object") 
			{
				hit.transform.GetComponent<InteractionGeneric> ().ShowInteractionMessage();
				if (Input.GetKeyDown (KeyCode.E)) {
					hit.transform.GetComponent<InteractionGeneric> ().Interaction ();
				}
			} 
			else
				textUI.enabled = false;
		}
		else
			textUI.enabled = false;
	}
}
