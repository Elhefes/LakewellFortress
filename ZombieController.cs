
using UnityEngine;
public class ZombieController : MonoBehaviour {

    public Transform Character; // Target Object to follow
    public float speed = 0.1F; // Enemy speed
    private Vector2 directionOfCharacter;
    private bool challenged = true;// If the enemy is Challenged to follow by the player
    

    public int move = 1;
    public Animator anim;
    private bool dead = false;
    ParticleSystem Blood
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }

    private ParticleSystem _CachedSystem;
    public bool includeChildren = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        Character = (Transform) GameObject.Find("player").GetComponent<Transform>();
        

    }
    void Update()
    {
        
       
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

    
    public void Die()
    {



        var main = Blood.main;
        main.playOnAwake = true;
            anim.Play("Die");
            dead = true;
            PointSystem.points += 1;
            Debug.Log("Zombie is dead");

            Destroy(GetComponent<PolygonCollider2D>());

        
      
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

            anim.Play("New State");

            

        } else if (dead ==false)
        { //kun ei osu
            
                anim.Play("Walk");
            
            
        }

    }

    
}

    
    


