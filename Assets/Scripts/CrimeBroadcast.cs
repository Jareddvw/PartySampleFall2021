using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimeBroadcast : MonoBehaviour {
	
    public static Collider2D[] objInRange;
	
	public float radius = 10;
	public string ignoreTag = "";

	public void Broadcast() {
		Vector2 pos = new Vector2(transform.position.x, transform.position.y);
		objInRange = Physics2D.OverlapCircleAll(pos, radius);

		foreach (var o in objInRange) {
			if (o.gameObject == gameObject || (!string.IsNullOrEmpty(ignoreTag) && o.CompareTag(ignoreTag))) continue;
			CrimeManager crimeManager = o.GetComponent<CrimeManager>();
			if (crimeManager) {
				Vector3 direction = o.transform.position - transform.position;
				direction.Normalize();
				float strInput = Vector3.Dot(direction, transform.right);
				if (strInput > 0) {
					crimeManager.TriggerCrime(direction, transform);
				}
			}
		}
	}
	
}