using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public float maxVol1;
	public float maxVol2;
	public float fadeLength;

	public AudioClip bgm1;
	public AudioClip bgm2;
	public AudioSource src1;
	public AudioSource src2;
	
	public void Awake() {
		src1.clip = bgm1;
		src1.volume = maxVol1;
		src1.loop = true;

		src2.clip = bgm2;
		src2.volume = 0;
		src2.loop = true;
		
		if (src1.clip) src1.Play();
		// if (src2.clip) src2.Play();

		var dc = FindObjectOfType<DeathCount>();
		if (dc) dc.deathEvent += OnSwitch;
	}

	public void OnSwitch() {
		StartCoroutine(FadeToBgm2());
	}

	public IEnumerator FadeToBgm2() {
		float startTime = Time.time;
		float past = 0;
		if (src2.clip) src2.Play();
		do {
			past = Time.time - startTime;
			var ratio = past / fadeLength;
			src1.volume = Mathf.Lerp(maxVol1, 0, ratio);
			src2.volume = Mathf.Lerp(0, maxVol2, ratio);
			yield return null;
		} while (past < fadeLength);

		src1.volume = 0;
		src2.volume = maxVol2;
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
