using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : InteractionGeneric {
	public bool isLooking = true;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		Debug.DrawRay (transform.position, fwd * 3, Color.red);

		if (Physics.Raycast (transform.position, fwd, out hit, 3, Physics.AllLayers, QueryTriggerInteraction.Collide))
		{
			if (hit.transform.tag == "Object" && isLooking) 
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
