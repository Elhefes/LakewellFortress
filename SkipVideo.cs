using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour {

	private Button skip;
	void Start () {
		skip = GameObject.Find ("Skip").GetComponent<Button> ();
		skip.onClick.AddListener(skipVideo);
	}
	
	void skipVideo() {
		SceneManager.LoadScene("Level1_Scene");
	}
}
