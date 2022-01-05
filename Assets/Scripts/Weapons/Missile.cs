using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Weapon
{
    public override void Shoot(Transform start)
    {
        fireTime -= Time.deltaTime;
        if (fireTime <= 0)
        {
            fireTime = fireRate;
            // Debug.Log("rocket shoot");
            if (sfx) AudioManager.PlaySFX(sfx, start.position);
            var b = Instantiate(bulletPrefab, start.position, start.rotation);
            b.GetComponent<Bullet>().playerTrans = playerTrans;
            cb?.Broadcast();
        }
    }
}
