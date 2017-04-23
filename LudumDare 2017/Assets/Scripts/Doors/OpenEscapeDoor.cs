using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEscapeDoor : MonoBehaviour {

	public float speed = 2f;

	private bool open = false;
	private Vector3 targetPosition;

	void Start ()
	{
		targetPosition = transform.GetChild (0).position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (open)
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed*Time.deltaTime);
	}

	public void Open ()
	{
		open = true;
	}
}
