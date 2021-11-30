using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpgrade : Item
{
    public Vector3 newSize;
    private Vector3 oldSize;
    public override void OnActivate()
    {
        oldSize = transform.localScale;
        transform.localScale = newSize;
        StartCoroutine(resetSize());
    }

    public IEnumerator resetSize()
    {
        Debug.Log("after 0 seconds");
        yield return new WaitForSeconds(2f);
        transform.localScale = oldSize;
        Debug.Log("after 2 seconds");
    }
}
