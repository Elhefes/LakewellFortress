using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZombieChild : MonoBehaviour
{
    public SoundController Sounds;
    public Transform Character; // Target Object to follow
    public float speed = 0.1F; // Enemy speed
    public Vector2 directionOfCharacter;
    public bool challenged = true;// If the enemy is Challenged to follow by the player
    public ZombieAnimation ZombieAnimation;
    
    private bool dead;
    private int move = 1;



    



    void Start()
    {
        PlayerController.playerspeed = 7f;
        ZombieAnimation = GetComponent<ZombieAnimation>();
        
        Debug.Log("Created Zombie");
        Character = (Transform)GameObject.Find("player").GetComponent<Transform>();
    Sounds =(SoundController)GameObject.Find("SoundController1").GetComponent<SoundController>();

    }

    void Update()
    {
        
        if (challenged && dead == false)
        {
            directionOfCharacter = Character.transform.position - transform.position;
            directionOfCharacter = directionOfCharacter.normalized; // Get Direction to Move Towards
            //transform.Translate(directionOfCharacter * 0.1F);


        }

        if (move == 1 && directionOfCharacter.GetHashCode() < 0 && dead == false)
        {
            transform.eulerAngles = new Vector2(0, 180);
            transform.Translate(Vector2.left * 4f * Time.deltaTime);
        }
        else if (move == 1 && dead == false)
        {
            transform.eulerAngles = new Vector2(0, 0);
            transform.Translate(Vector2.left * 4f * Time.deltaTime);
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

            PointSystem.health -= 30;

            ZombieAnimation.animPlay("New State");

            
            Sounds.playZombieAudio();


        }
        else if (dead == false)
        { //kun ei osu
            
            if (ZombieAnimation.anim != null)
            ZombieAnimation.animPlay("Walk");


        }

    }
    public void Die()
    {




        
        ZombieAnimation.animPlay("DieAnim");
        
        dead = true;
        PointSystem.points += 1;
        Debug.Log("Zombie is dead");
        if (ZombieAnimation.ZombieCollider2D != null)
        {
            Destroy(ZombieAnimation.ZombieCollider2D);
        }
        if (ZombieAnimation.ZombieRigidbody2D != null)
        {
            Destroy(ZombieAnimation.ZombieRigidbody2D);
        }
        if (ZombieAnimation.ZombieBlood != null)
        {
            ZombieAnimation.ZombieBlood.Play();
        }



    }


}





