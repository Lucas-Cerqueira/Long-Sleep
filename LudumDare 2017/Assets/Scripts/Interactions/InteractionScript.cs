using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		if (Physics.Raycast (transform.position, fwd, out hit, 10.0f, Physics.AllLayers, QueryTriggerInteraction.Collide))
		{
			if (hit.transform.tag == "Object")
			{
				if (Input.GetKeyDown (KeyCode.E)) 
				{
					hit.transform.GetComponent<InteractionGeneric> ().Interaction ();
				}
			}
		}
	}
}
