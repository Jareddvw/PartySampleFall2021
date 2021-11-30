using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenBoost : Item
{
    public BoostManager BM;
    private float oldBoostDischargeRate;
    public override void OnActivate()
    {
        BM = GetComponent<BoostManager>();
        oldBoostDischargeRate = BM.boostDischargeRate;
        BM.boostDischargeRate = 0;
        StartCoroutine(Stop());
    }

    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(2f);
        BM.boostDischargeRate = oldBoostDischargeRate;
    }
}
