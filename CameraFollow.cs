using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	private Transform target;
	//gets the positional information of player
	void Start () {
		target = GameObject.Find ("player").GetComponent<Transform>();
	}
	//updates the camera's position to match the player's position
	//with a small smoothing effect
	void Update () {
		if (target) {
			transform.position = Vector2.Lerp (transform.position, target.position, 0.1f);
		}
	}
}