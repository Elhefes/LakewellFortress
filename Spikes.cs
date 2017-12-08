using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D coll)
	{
		Scene scene = SceneManager.GetActiveScene();


		if (coll.gameObject.tag == "Player") {
			PointSystem.health -= 100;

		}
	}
}
