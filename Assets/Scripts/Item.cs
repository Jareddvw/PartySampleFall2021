﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite itemImage;
    public int cost;
    public bool canBuy = true;

    public virtual void OnActivate()
    {
        Debug.Log(itemName);
    }
}
