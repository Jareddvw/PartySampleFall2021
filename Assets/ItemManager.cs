using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item Health;

    public void ActivateHealth()
    {
        Health.OnActivate();    
    }
}
