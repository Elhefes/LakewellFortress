using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintName : Name {
	public GameObject[] nametext;
	// Use this for initialization
	Text txt;
	void Start () {

		txt= (Text) GameObject.Find("Text").GetComponent<Text>();
		txt.text = Name.characterName;
		nametext = GameObject.FindGameObjectsWithTag("nameText");
		Debug.Log (characterName);
        /*
		Name nimi = new Name ();
		if (Input.GetKeyDown (KeyCode.W)) {
			string haha = nimi.GetName ();
			Debug.Log (haha);
		} */
	    TimeHide();
    }
	private double time= 10.0;
	private double time2= 20.0;
	public static double sec;

    void Update()
    {
        /*	Debug.Log ("updateee");
            //time = VideoPlayerControler.seconds;
    
            if (time<sec && sec<time2) {
                Debug.Log ("10-20");
                foreach (GameObject a in nametext) {
                    a.SetActive(true);
    
                }
            } else {
                Debug.Log ("hi");
                foreach (GameObject a in nametext) {
                    a.SetActive(false);
                }
        */
    }

    public void TimeShow()
        {
            Debug.Log("Timeshow");
            foreach (GameObject a in nametext)
            {
                a.SetActive(true);
            }
        }

    public void TimeHide()
    {
        Debug.Log("TimeHide");
        foreach (GameObject a in nametext)
        {
            a.SetActive(false);
        }
    }
    }
