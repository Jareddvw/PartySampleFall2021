﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostManager : MonoBehaviour
{
    /* need 2 values: max boost amount, current boost amount
     * need recovery/recharge rate of boost juice
     * need rate of boost discharge when boosting
     * need prefabs for ui that we can change
     * 
     * 
     */

    public BasicVehicleInputHandler basicVehicleInputHandler;
    public float maxBoostAmount;
    public float currentBoostAmount;
    public float boostRechargeRate;
    private float boostRechargeRateDisabled;
    private float boostRechargeRateNormal;
    public float boostDischargeRate;
    public bool canBoost;

    public float nitroBoostAmount;

    public Slider boostUI;
    public Color disabledColor;
    private Color fillColor;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        boostRechargeRateDisabled = boostRechargeRate / 4;
        boostRechargeRateNormal = boostRechargeRate;
        currentBoostAmount = maxBoostAmount;
        if (boostUI == null)
            return;
        fillColor = fill.color;
        boostUI.maxValue = maxBoostAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (boostUI) boostUI.value = currentBoostAmount;
    }

    public void RechargeBoost()
    {
        currentBoostAmount += boostRechargeRate * Time.deltaTime;
        currentBoostAmount = Mathf.Clamp(currentBoostAmount, 0, maxBoostAmount);
    }

    public void DischargeBoost()
    {
        currentBoostAmount -= boostDischargeRate * Time.deltaTime;
        currentBoostAmount = Mathf.Clamp(currentBoostAmount, 0, maxBoostAmount);
        if (currentBoostAmount <=0.5f)
        {
            canBoost = false;
            
            StartCoroutine(boostCooldown(2));
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Nitro")) {
            currentBoostAmount += nitroBoostAmount;
            currentBoostAmount = Mathf.Clamp(currentBoostAmount, 0, maxBoostAmount);
            Destroy(collider.gameObject);
        }
    }

    public IEnumerator boostCooldown(int seconds)
    {
        boostRechargeRate = boostRechargeRateDisabled;
        yield return new WaitForSeconds(seconds);
        boostRechargeRate = boostRechargeRateNormal;
    
        canBoost = true;
    }
}


