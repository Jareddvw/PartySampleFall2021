using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform start)
    {
        if (fireTime <= 0 && ammo > 0) {
            ammo -= 1;
            fireTime = fireRate;
            if (sfx) AudioManager.PlaySFX(sfx, start.position);
            // Debug.Log("shotgun shoot");
            var b = Instantiate(bulletPrefab, start.position, start.rotation);
            b.GetComponent<Bullet>().playerTrans = playerTrans;
            b = Instantiate(bulletPrefab, start.position, start.rotation * Quaternion.Euler(new Vector3(0, 0, -5)));
            b.GetComponent<Bullet>().playerTrans = playerTrans;
            b = Instantiate(bulletPrefab, start.position, start.rotation * Quaternion.Euler(new Vector3(0, 0, +5)));
            b.GetComponent<Bullet>().playerTrans = playerTrans;
            cb?.Broadcast();
        }
    }
}
