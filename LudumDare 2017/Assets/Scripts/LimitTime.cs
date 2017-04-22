using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitTime : MonoBehaviour {
	public float limitTime = 600.0f;
	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > limitTime)
			print ("Acabou o tempo");
	}
}
