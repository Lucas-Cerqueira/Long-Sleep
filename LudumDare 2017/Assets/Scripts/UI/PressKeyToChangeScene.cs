using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressKeyToChangeScene : MonoBehaviour {

	public Texture[] screensList;
	public string nextSceneName;

	private int currentIndex = 0;
	private RawImage imageComponent;

	// Use this for initialization
	void Start ()
	{
		imageComponent = GetComponent<RawImage> ();
		imageComponent.texture = screensList [currentIndex];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKeyDown && currentIndex < screensList.Length) 
		{
			currentIndex++;
			if (currentIndex < screensList.Length)
				imageComponent.texture = screensList [currentIndex];
		}

		if (currentIndex == screensList.Length)
			SceneManager.LoadScene ("mainScene", LoadSceneMode.Single);
	}
}
