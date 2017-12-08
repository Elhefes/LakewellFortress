using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nimivic : MonoBehaviour
{
    public Text nimi;
	// Use this for initialization
	void Start ()
	{
	    nimi = GameObject.Find("nimi").GetComponent<Text>();
	    nimi.text = "Gongratulations " + Name.characterName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
