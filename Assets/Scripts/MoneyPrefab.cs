using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPrefab : MonoBehaviour
{
    public int cashAmount;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Debug.Log(cashAmount);
            Destroy(gameObject);
        }
    }
}
