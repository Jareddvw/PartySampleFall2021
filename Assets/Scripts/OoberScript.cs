using System;
using UnityEngine;
using UnityEngine.UI;

public class OoberScript : MonoBehaviour {

	public Color original;
	public Color tint;

	public float interval;
	public float duration;

	private Image _img;
	private float _lastTime;
	private float _playTime;
	private bool forwards = true;

	private void Awake() {
		_img = GetComponent<Image>();
		original = _img.color;
		// Destroy(gameObject, duration + .01f);
		// _lastTime = Time.time;
	}

	public void Play() {
		_lastTime = Time.time;
		_playTime = _lastTime;
	}

	private void Update() {
		var currTime = Time.time;
		if (currTime - _playTime >= duration) {
			gameObject.SetActive(false);
			return;
		}
		var past = currTime - _lastTime;
		if (past > interval) {
			past -= interval;
			_lastTime = currTime - past;
			forwards = !forwards;
		}
		var start = forwards ? original : tint;
		var end = forwards ? tint : original;
		_img.color = Color.Lerp(start, end, past / interval);
	}
}