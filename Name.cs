using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Name : MonoBehaviour {

	public GameObject[] invalid;
	//public string playerName;
	public InputField input;
	public static string characterName;
	public bool pressed= false;
	private Button go;
	
	void Start () {

		go = GameObject.Find ("Go").GetComponent<Button> ();
		go.onClick.AddListener(nameGiven);
		invalid = GameObject.FindGameObjectsWithTag("Invalid");
		
		var input = gameObject.GetComponent<InputField>();
		var nameField = new InputField.SubmitEvent ();
		//playerName = name;
		nameField.AddListener (giveName);
		input.onEndEdit = nameField;
		hideInvalid ();
	
	}
	public void nameGiven() {
		pressed = true;
	}
	public void giveName (string name) {
		
		if (Input.GetKeyDown (KeyCode.Return) || pressed) {
			if (name.Length > 3) {
				
				SceneManager.LoadScene ("MenuScene");
				Debug.Log (name);
				characterName = name;

			} else {
				Debug.Log ("too few characters");
				foreach (GameObject b in invalid)
				{
					b.SetActive(true);
				}
			}
		}
	}



	public void hideInvalid()
	{
		foreach (GameObject b in invalid)
		{
			b.SetActive(false);
		}
	}
	void Update () {
		//Debug.Log (name);	
	}
}