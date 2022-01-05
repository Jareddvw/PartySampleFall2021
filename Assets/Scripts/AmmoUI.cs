using System;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour {

	public Text text;
	public Weapon weapon;
	public int ammoCount;

	private void Awake() {
		if (!text) text = GetComponent<Text>();
		UpdateUI();
	}

	private void Update() {
		if (weapon.ammo != ammoCount) {
			ammoCount = weapon.ammo;
			UpdateUI();
		}
	}

	private void UpdateUI() {
		text.text = "x " + ammoCount;
	}
}