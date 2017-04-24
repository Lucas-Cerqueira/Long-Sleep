using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOrder : MonoBehaviour {
	public AudioSource src;
	public AudioClip [] audios;
	public GameObject limitTime;
	private float targetTime;
	private int musicCounter = 0;
	private bool isChanging = false;
	private bool changed = false;
	private IEnumerator coroutine;
	private IEnumerator coroutine2;

	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource> ();
		coroutine = FadeOut(src,2000.0f);
		coroutine2 = FadeIn (src, 600.0f, src.volume);
	}
	
	// Update is called once per frame
	void Update () {
		targetTime = limitTime.GetComponent<LimitTime> ().getTargetTime();
		float remainingTime = targetTime - Time.time;
		if (remainingTime <= 60.0f && !changed) {
			isChanging = true;
			changed = true;
		}
		//print (remainingTime + " " + isChanging + " " + src.time + " " + src.clip.length);
		if (src.time + 5.0f >= src.clip.length) {
			StartCoroutine (coroutine);
		}
		if (isChanging && src.time + 0.5f >= src.clip.length) {
			src.Stop ();
			src.clip = audios [1];
			src.Play ();
			src.volume = 1;
			isChanging = false;
		}
	}

	public IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
		float startVolume = audioSource.volume;

		while (audioSource.volume > 0 && audioSource.time - audioSource.clip.length > 1.0f) {
			//print ("Volume :" + audioSource.volume + " " + audioSource.clip.ToString());
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}

		if (!isChanging) {			
			audioSource.Stop ();
			audioSource.Play ();
			audioSource.volume = 1;
		}
		audioSource.volume = startVolume;
	}

	public IEnumerator FadeIn (AudioSource audioSource, float FadeTime, float finishVolume) {
		float startVolume = 1.0f;

		while (audioSource.volume < finishVolume) {
			audioSource.volume += startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}

		audioSource.Stop ();
		if (!isChanging)
			audioSource.Play ();
		audioSource.volume = startVolume;
	}
}
