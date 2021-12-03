using System;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour {

	private static DeathCount instance;

	public Text deathCountUI;
	public int intenseLevel = 10;
	public GameObject ooberImage;
	public event Action deathEvent;

	public int Count {
		get => _count;
		set {
			_count = value;
			if (_count >= intenseLevel) deathEvent?.Invoke();
			UpdateUI();
		}
	}

	public int _count;

	private void Awake() {
		instance = this;
		deathEvent += () => {
			if (ooberImage) ooberImage.SetActive(true);
		};
		UpdateUI();
	}

	private void UpdateUI() => deathCountUI.text = "Öö# : " + Count;

	public static void CountOne() {
		if (!instance) return;
		instance.Count += 1;
	}
}