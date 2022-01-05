using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboMeter : MonoBehaviour
{
    public float timeRemaining = 5f;
    public float onKillTimeReward = 5f;
    public float nitroReward;
    public int rewardMin = 2;
    public int comboTextCount = 5;
    public bool onCombo;
    public int killCount;
    public BoostManager boostManager;
    public GameObject comboUI;
    public CanvasGroup group;
    public Text comboText;
    public GameObject ooberImage;

    private void Awake() {
        if (!boostManager) boostManager = GetComponent<BoostManager>();
        if (comboUI && !comboText) {
            group = comboUI.GetComponent<CanvasGroup>();
            comboText = comboUI.GetComponentInChildren<Text>();
        }
        comboUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(onCombo)
        {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                group.alpha = Mathf.Clamp01(timeRemaining / onKillTimeReward);
            }
            else
            {
                // Debug.Log("Time has run out!");
                timeRemaining = 0;
                onCombo = false;
                if (comboUI) comboUI.SetActive(false);
                killCount = 0;
            }
        }
    }

    public void OnKill()
    {
        onCombo = true;
        timeRemaining = onKillTimeReward;
        killCount += 1;

        if (comboUI) {
            if (!comboUI.activeSelf) comboUI.SetActive(true);
            if (comboText) {
                comboText.text = "X " + killCount;
                group.alpha = 1f;
            }
        }

        if (killCount >= rewardMin) {
            if (boostManager) {
                boostManager.currentBoostAmount += nitroReward;
                boostManager.currentBoostAmount = Mathf.Clamp(boostManager.currentBoostAmount, 0, boostManager.maxBoostAmount);
            }
        }
        
        if (killCount >= comboTextCount) {
            if (ooberImage) {
                ooberImage.SetActive(true);
                ooberImage.GetComponent<OoberScript>().Play();
            }
        }
    }

}
