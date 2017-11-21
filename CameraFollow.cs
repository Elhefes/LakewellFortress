using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	private Transform target;
	void Start () {
		target = GameObject.Find ("placeholderPlayer").GetComponent<Transform>();
	}
	void Update () {
		if (target) {
			transform.position = Vector2.Lerp (transform.position, target.position, 0.1f);
		}
	}
}