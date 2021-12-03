using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpgrade : Item
{
    public Vector3 newSize;
    public float duration = 10f;
    private Vector3 oldSize;
    public override void OnActivate() {
        canBuy = false;
        oldSize = transform.localScale;
        transform.localScale = newSize;
        StartCoroutine(resetSize());
    }

    public IEnumerator resetSize()
    {
        // Debug.Log("after 0 seconds");
        yield return new WaitForSeconds(duration);
        transform.localScale = oldSize;
        // Debug.Log("after 2 seconds");
        canBuy = true;
    }
}
