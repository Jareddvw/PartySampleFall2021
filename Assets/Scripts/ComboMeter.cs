using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboMeter : MonoBehaviour
{
    public float timeRemaining = 5f;
    public float onKillTimeReward = 5f;
    public bool onCombo;
    public int killCount;

    // Update is called once per frame
    void Update()
    {
        if(onCombo)
        {
            if (timeRemaining > 0)         
                timeRemaining -= Time.deltaTime;
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                onCombo = false;
                killCount = 0;  
            }
        }
    }

    public void OnKill()
    {
        onCombo = true;
        timeRemaining += onKillTimeReward;
        killCount += 1;
    }

}
