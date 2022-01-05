using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenBoost : Item
{
    public BoostManager BM;
    public float duration = 10f;
    private float oldBoostDischargeRate;
    public override void OnActivate() {
        canBuy = false;
        BM = GetComponent<BoostManager>();
        oldBoostDischargeRate = BM.boostDischargeRate;
        BM.boostDischargeRate = 0;
        StartCoroutine(Stop());
    }

    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(duration);
        BM.boostDischargeRate = oldBoostDischargeRate;
        canBuy = true;
    }
}
