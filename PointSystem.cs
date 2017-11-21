using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public static int health = 100;
    public static int points;
    public Text healthText;
    public Text pointsText;
	// Use this for initialization
	void Start ()
	{
	   healthText = (Text) GameObject.Find("HealthText").GetComponent<Text>();
	   pointsText = (Text)GameObject.Find("PointsText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

	    healthText.text = "Health: " + health;
	    pointsText.text = "Points: " + points;
	}
}
