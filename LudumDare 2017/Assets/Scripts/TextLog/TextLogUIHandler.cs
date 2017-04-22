using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogUIHandler : MonoBehaviour {

	private Image image;
	private GameObject text;
	private bool enabled = false;

	// Use this for initialization
	void Start () 
	{
		image = GetComponent<Image> ();
		text = transform.GetChild (0).gameObject;
	}
	
	public void Enable ()
	{
		image.enabled = true;
		text.SetActive (true);
		enabled = true;
	}

	public void Disable ()
	{
		image.enabled = false;
		text.SetActive (false);
		enabled = false;
	}

	void Update ()
	{
		if (enabled && (Input.GetKeyDown (KeyCode.Escape) || Input.GetMouseButtonDown (0)))
			Disable ();
			
	}
}
