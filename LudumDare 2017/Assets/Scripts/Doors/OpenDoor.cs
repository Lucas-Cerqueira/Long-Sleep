using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
	private Transform endMarker;
	private Transform startMarker;
	public float speed = 1.0f;
	private float startTime;
	private float journeyLenght;
	private bool isOpening = false;

	// Use this for initialization
	void Start () {
		startMarker = transform;
		endMarker = transform.GetChild (0).transform;
		journeyLenght = Vector3.Distance (startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpening) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLenght;
			transform.position = Vector3.Lerp (startMarker.position, endMarker.position, fracJourney);
			if (Vector3.Distance(transform.position,endMarker.position) < 1.38936f) {
				isOpening = false;
				gameObject.SetActive(false);
			}
		}
	}

	public void OpenDoors()
	{
		startTime = Time.time;
		isOpening = true;
	}
}
