using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int cost;
    public float fireRate = 0.2f;
    public float fireTime = 0;

    public virtual void Shoot(Transform start)
    {
        
    }

    public void Update()
    {
        Debug.Log("yeet");
    }
}
