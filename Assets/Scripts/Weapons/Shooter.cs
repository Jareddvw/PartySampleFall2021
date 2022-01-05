﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shooter : MonoBehaviour
{
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;
    public TextMeshProUGUI primartext;
    public TextMeshProUGUI secondartext;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public KeyCode fire;
    public KeyCode fire1;
    public float cursorDist = 3.5f;
    public Transform cursor;

    private Vector3 mousePosition;

    private Camera _mainCamera;

    private void Awake() => _mainCamera = Camera.main;

    // Update is called once per frame
    void Update()
    {
        /*
        mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        var selfPos = firePoint.position;
        mousePosition = selfPos + (mousePosition - selfPos).normalized * cursorDist;
        if (cursor) cursor.position = mousePosition;
        firePoint.up = (mousePosition - firePoint.position).normalized;
        */

        if (Input.GetKey(fire)){
            Shoot();
        }
        /*
        if (Input.GetKey(fire1))
        {
            ShootAlternate();
        }
        */
    }

    private void FixedUpdate() {
        mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -7;
        var selfPos = firePoint.position;
        selfPos.z = -7;
        mousePosition = selfPos + (mousePosition - selfPos).normalized * cursorDist;
        if (cursor) cursor.position = mousePosition;
        firePoint.up = (mousePosition - firePoint.position).normalized;
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


    public void unequipPrimary()
    {
        primaryWeapon = null;
        primartext.text = string.Empty;

    }

    public void unequipSecondary()
    {
        secondaryWeapon = null;
        secondartext.text = string.Empty;
    }
}
