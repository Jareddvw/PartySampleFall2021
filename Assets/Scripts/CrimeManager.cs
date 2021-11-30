using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CrimeManager : MonoBehaviour {

	public Action<Vector3, Transform> onCrimeHappen;

	public void TriggerCrime(Vector3 dir, Transform transform) {
		onCrimeHappen?.Invoke(dir, transform);
	}
}
