using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static int Bossdamage;
	// Use this for initialization
	void Start ()
	{
	    if (SettingController.Difficulty == 2)
	    {
	        Bossdamage = 100;
	    } else if (SettingController.Difficulty == 1)
	    {
	        Bossdamage = 50;
	    } else if (SettingController.Difficulty == 0)
	    {
	        Bossdamage = 20;
	    }
	}

    public void updateDamage()
    {
        Start();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
