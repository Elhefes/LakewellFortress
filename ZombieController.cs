using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class ZombieController : MonoBehaviour {

    public Transform Character; // Target Object to follow
    public float speed = 0.1F; // Enemy speed
    private Vector2 directionOfCharacter;
    private bool challenged = true;// If the enemy is Challenged to follow by the player
    private ParticleSystem Blood;

    public int move = 1;
    public Animator anim;
    private bool dead = false;
    
    
    void Start()
    {
        anim = GetComponent<Animator>();
        Character = (Transform) GameObject.Find("placeholderPlayer").GetComponent<Transform>();
        Blood = (ParticleSystem) GameObject.Find("Zombie").GetComponent<ParticleSystem>();

    }
    void Update()
    {
        
       Die();
        if (challenged)
        {
            directionOfCharacter = Character.transform.position - transform.position;
            directionOfCharacter = directionOfCharacter.normalized; // Get Direction to Move Towards
            //transform.Translate(directionOfCharacter * 0.1F);
          

        }
        
        if (move == 1 && directionOfCharacter.GetHashCode() < 0 && dead == false)
        {
            transform.eulerAngles = new Vector2(0, 180);
			transform.Translate (Vector2.left * 4f * Time.deltaTime);
        }
        else if (move == 1 && dead == false)
        {
            transform.eulerAngles = new Vector2(0, 0);
			transform.Translate (Vector2.left * 4f * Time.deltaTime);
        }

    }

    int asd;
    public void Die()
    {
        if (transform.position == PlayerController.diepos)
        {
            Blood.Play();
            anim.Play("Die");
            dead = true;
            Debug.Log("Zombie is dead");
            
            Destroy(GetComponent<PolygonCollider2D>());

        }
    }
// Will be triggered as soon as player would touch the Enemy Object
   
    void OnCollisionEnter2D(Collision2D coll)
    {
        //jos while käytössä tarkistaa jatkuvasti, nyt tarkistaa osuman. 
        //Ei voi käyttää poislähtiessä eli vain kun osuu pelaajaan tekee jotain    
        //kun osuu pelaajaan
        
        if (coll.gameObject.tag == "Player" && dead == false)
        {
            Debug.Log("Osuma oikea!!!!!!!");

            PointSystem.health -= 1;

            anim.Play("New State");

            

        } else if (dead ==false)
        { //kun ei osu
            
                anim.Play("Walk");
            
            
        }

    }
    
    







}

    
    


