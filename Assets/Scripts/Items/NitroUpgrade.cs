using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroUpgrade : Item
{
    public BoostManager bm;
    public float maxBoostUpgrade;
    public override void OnActivate()
    {
        bm = FindObjectOfType<BoostManager>();
        Debug.Log("Nitro Upgrade");
        bm.maxBoostAmount += maxBoostUpgrade;
    }
}
