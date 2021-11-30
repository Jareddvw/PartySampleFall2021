using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public KeyCode fire;
    public KeyCode fire1;

    public Transform cursor;

    private Vector3 mousePosition;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        if (cursor) cursor.position = mousePosition;
        firePoint.up = (mousePosition - firePoint.position).normalized;

        if (Input.GetKey(fire)){
            Shoot();
        }
        if (Input.GetKey(fire1))
        {
            ShootAlternate();
        }
    }

    void Shoot(){
        if (primaryWeapon == null)
            return;
        primaryWeapon.Shoot(firePoint);
    }

    void ShootAlternate()
    {
        if (secondaryWeapon == null)
            return;
        secondaryWeapon.Shoot(firePoint);
    }
}
