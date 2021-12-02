using UnityEngine;

public class SimpleVFXPlayer : MonoBehaviour {

	public float duration;
	public Vector3 startSize;
	public Vector3 endSize;
	public bool autoDestroy;

	private float _startTime;

	private void Awake() {
		_startTime = Time.time;
		transform.localScale = startSize;
		if (autoDestroy) Destroy(gameObject, duration);
		else Destroy(this, duration);
	}

	private void Update() {
		var size = Vector3.Lerp(startSize, endSize, (Time.time - _startTime) / duration);
		transform.localScale = size;
	}
}