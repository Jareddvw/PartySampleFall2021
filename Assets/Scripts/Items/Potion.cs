using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    //Reference to which Does not Exist
    HealthScript health;
    public int amount;
    public override void OnActivate()
    {
        print(gameObject.name);
        health = GetComponent<HealthScript>();
        print(health == null);
        health.OnHealthRestore(amount);
        Debug.Log("Restore Health");
    }
}
