using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip bgm;
	
	public void Awake() {
		var audioSource = GetComponent<AudioSource>();
		if (audioSource == null) {
			audioSource = gameObject.AddComponent<AudioSource>();
		}

		audioSource.clip = bgm;
		audioSource.loop = true;
		
		if (audioSource.clip) audioSource.Play();
	}
	
	public static void PlaySFX(AudioClip sfx, Vector3 pos) {
		GameObject go = new GameObject();
		var src = go.AddComponent<AudioSource>();
		src.spatialize = true;
		// print("I'm here!");
		src.PlayOneShot(sfx);
		Destroy(go, sfx.length + .01f);
	}
}
