using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePodWindow : MonoBehaviour {

	public float degreesToRotate = 90f;
	public float time = 2f;

	private bool close = false;
	private bool setChild = false;
	private Quaternion initialRotation;
	private Quaternion targetRotation;
	private float t = 0;

	// Use this for initialization
	void Start () 
	{
		initialRotation = transform.rotation;
		targetRotation = Quaternion.Euler (transform.eulerAngles.x - degreesToRotate, transform.eulerAngles.y, transform.eulerAngles.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (close) {
			transform.rotation = Quaternion.Lerp (initialRotation, targetRotation, t);

			if (t < 1)
				t += Time.deltaTime / time;
			else {
				if (!setChild) {
					setChild = true;
					transform.SetParent (GameObject.Find ("Escape_Pod1").transform);
					GameObject.Find ("Escape_Pod1").GetComponent<InteractionEscapePod> ().SetPlayerInside (true);
				}
			}
		}
	}

	public void Close()
	{
		close = true;
	}
}
