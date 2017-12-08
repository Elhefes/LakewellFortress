using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonoBehaviour {

	public Transform Character; // Target Object to follow
	public float speed = 0.1F; // Enemy speed
	private Vector2 directionOfCharacter;
	private bool challenged = true;// If the enemy is Challenged to follow by the player
	private Collider2D orc;

	public int move = 1;
	public Animator anim;



	void Start()
	{
		anim = GetComponent<Animator>();
		Character = (Transform) GameObject.Find("player").GetComponent<Transform>();
		orc = (Collider2D) GameObject.Find("Orc").GetComponent<Collider2D>();
	}
	void Update()
	{

		if (challenged)
		{
			directionOfCharacter = Character.transform.position - transform.position;
			directionOfCharacter = directionOfCharacter.normalized; // Get Direction to Move Towards
			//transform.Translate(directionOfCharacter * 0.1F);


		}

		if (move == 1 && directionOfCharacter.GetHashCode() < 0)
		{
			transform.eulerAngles = new Vector2(0, 0);
			transform.Translate (Vector2.right * 4f * Time.deltaTime);
		}
		else if (move == 1)
		{
			transform.eulerAngles = new Vector2(0, 180);
			transform.Translate (Vector2.right * 4f * Time.deltaTime);
		}

	}
	// Will be triggered as soon as player would touch the Enemy Object

	void OnCollisionEnter2D(Collision2D coll)
	{
		//jos while käytössä tarkistaa jatkuvasti, nyt tarkistaa osuman. 
		//Ei voi käyttää poislähtiessä eli vain kun osuu pelaajaan tekee jotain    
		//kun osuu pelaajaan
		if (coll.gameObject.tag == "Player")
		{
			Debug.Log("Osuma oikea!!!!!!!");

			anim.Play("OrcAttackAnimation");


		} else
		{ //kun ei osu

			anim.Play("OrcWalkAnimation");

			Debug.Log("ei osu pelaajaan!!!!!!!");
		}

	}









}





