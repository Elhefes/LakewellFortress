using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileControl : PlayerController {

	private Button leftButton;
	private Button rightButton;
	private Button jumpButton;
	private Button attackButton;
	private Button pauseButton;
	PointerController right;
	PointerController left;
	PointerController jump;
    
    /// <summary>
    /// if pausemenus continuebutton is pressed
    /// </summary>
    public static bool Continue;
	
    public GameObject PlayerGameObject;
	public GameObject[] pauseObjects;
	public GameObject[] mobileObjects;

	void Start () {
		Anim = GetComponent<Animator>();
        play = (Rigidbody2D) GameObject.Find("player").GetComponent<Rigidbody2D>();
		Player = (Transform)GameObject.Find("player").GetComponent<Transform>();
		mobileObjects = GameObject.FindGameObjectsWithTag("MobileControls");
		//leftButton = GameObject.Find ("LeftButton").GetComponent<Button> ();
		//rightButton = GameObject.Find ("RightButton").GetComponent<Button> ();
		jumpButton = GameObject.Find ("JumpButton").GetComponent<Button> ();
		attackButton = GameObject.Find ("AttackButton").GetComponent<Button> ();
		pauseButton = GameObject.Find ("PauseButton").GetComponent<Button> ();
		right = GameObject.Find ("RightButton").GetComponent<PointerController> ();
		left = GameObject.Find ("LeftButton").GetComponent<PointerController> ();
		jump = GameObject.Find ("JumpButton").GetComponent<PointerController> ();

		//leftButton.OnPointerDown
		//leftButton.onClick.AddListener(moveleft);

		//rightButton.onClick.AddListener(rightButtonClicked);
		//jumpButton.onClick.AddListener(jumpButtonClicked);
		//leftButton.onClick.AddListener(leftButtonClicked);
		attackButton.onClick.AddListener(attackButtonClicked);
		pauseButton.onClick.AddListener(pauseButtonClicked);
		    showMobile ();
        
	}

    void attackButtonClicked()
    {
        Debug.Log("Attack button pressed");
        base.playerHit();
    }
    void pauseButtonClicked()
    {
        PauseController.pausenow = 1;
        hideMobile();
    }
	// Update is called once per frame
	void Update () {
		
		if (left.getPressed ()) {
			base.moveleft();
		}
		if (right.getPressed ()) {
			base.moveright ();
		}
		if (jump.getPressed ()) {
			base.jump();
		}

		Move ();
		/*if (Input.GetButton("rightButton")) {

			moveright ();
		}
		if (Input.GetButton("leftButton")) {

			moveleft ();
		} */
	    if (Continue)
	    {
	        showMobile();
	        Continue = false;
	    }
		//if (Time.timeScale == 1) {
		//	showMobile ();
		//}
	//}
	//void jumpButtonClicked ()  {
	//	base.jump ();
	}
	/*void leftButtonClicked() {
		if (Input.GetButton("leftButton")) {
			
			base.moveleft();
		}

	} 
	void rightButtonClicked() {
		if (Input.GetButton("rightButton")) {

			base.moveleft();
		}

	} */
	
	public void showMobile()
	{
		foreach (GameObject a in mobileObjects)
		{
			a.SetActive(true);
		}
	}
	public void hideMobile()
	{
		foreach (GameObject a in mobileObjects)
		{
			a.SetActive(false);
		}
	}
	
}