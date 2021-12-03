using UnityEngine;

public class Ammo : Item {

	public Weapon weapon;
	public int amount = 5;
	
	public override void OnActivate() {
		weapon.ammo += amount;
	}
}