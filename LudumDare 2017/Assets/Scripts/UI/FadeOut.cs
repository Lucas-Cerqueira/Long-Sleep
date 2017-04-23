using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

	public float fadeOutTime = 2f;

	private Image image;
	private float alpha = 255;
	private float t = 0;

	// Use this for initialization
	void Start () 
	{
		image = GetComponent<Image> ();
		image.CrossFadeAlpha (0, fadeOutTime, false);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
