using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Weapon
{
    public LineRenderer lr;
    public override void Shoot(Transform start)
    {
        fireTime -= Time.deltaTime;
        if (fireTime <= 0)
        {
            lr = GetComponent<LineRenderer>();
            fireTime = fireRate;
            lr.SetPosition(0, start.position);
            Debug.Log("sniper shoot");
            RaycastHit2D hit = Physics2D.Raycast(start.position, start.forward * 100f);
            if (hit.collider != null)
            {
                lr.SetPosition(1, hit.collider.transform.position);
                Debug.Log("hit");
            }
            else
            {
                lr.SetPosition(1, start.forward*20f);
                Debug.Log("not hit");
            }

        }
    }
}
