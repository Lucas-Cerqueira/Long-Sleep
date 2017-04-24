using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {

	public float fadeOutTime = 2f;

	private Image image;
	private bool fadeIn;
	private bool fadeOut;

	// Use this for initialization
	void Start () 
	{
		image = GetComponent<Image> ();
		FadeOut ();
	}

	void Update ()
	{
		if (fadeOut)
			image.color = new Color (image.color.r, image.color.g, image.color.b, Mathf.Clamp(image.color.a - Time.deltaTime/fadeOutTime, 0, 255));
		else if (fadeIn)
			image.color = new Color (image.color.r, image.color.g, image.color.b, Mathf.Clamp(image.color.a + Time.deltaTime/fadeOutTime, 0, 255));
	}

	public void FadeIn ()
	{
		fadeIn = true;
		fadeOut = false;
	}
	public void FadeOut ()
	{
		fadeIn = false;
		fadeOut = true;
	}
}
