using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public KeyCode restartKey = KeyCode.R;
	public KeyCode quitKey = KeyCode.Q;

	public void Update() {
		if (Input.GetKeyUp(restartKey)) {
			var scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.buildIndex);
		}

		if (Input.GetKeyUp(quitKey)) {
			Application.Quit();
		}
	}
}
