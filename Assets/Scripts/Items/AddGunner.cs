using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGunner : Item
{
    public Shooter shooter;
    public override void OnActivate()
    {
        shooter.enabled = true;
    }
}
