using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    public override void Shoot(Transform start)
    {
        fireTime -= Time.deltaTime;
        if (fireTime <= 0) {
            fireTime = fireRate;
            if (sfx) AudioManager.PlaySFX(sfx, start.position);
            // Debug.Log("pistol shoot");
            var b = Instantiate(bulletPrefab, start.position, start.rotation);
            b.GetComponent<Bullet>().playerTrans = playerTrans;
            cb?.Broadcast();
        }
    }
}
