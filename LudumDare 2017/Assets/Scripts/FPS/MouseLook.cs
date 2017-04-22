using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public float sensibilityX = 2;
	public float sensibilityY = 2;
	public float verticalClamp = 80f;

	private float rotationX = 0f;
	private float rotationY = 0f;


	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		rotationX += Input.GetAxis ("Mouse X") * sensibilityX;
		rotationY += -Input.GetAxis ("Mouse Y") * sensibilityY;
		rotationY = Mathf.Clamp (rotationY, -verticalClamp, verticalClamp);

		transform.localEulerAngles = new Vector3 (rotationY, rotationX, 0);
	}
}
