using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float playerspeed;
    public Rigidbody2D play;
    /// <summary>
    /// Check if player is on ground or not.
    /// </summary>
	public bool onGround;
    public Transform Character;
    /// <summary>
    /// Animation
    /// </summary>
    public Animator Anim;
    public Transform Player;
    /// <summary>
    /// Direction of player
    /// </summary>
    public bool dirright = true;
    /// <summary>
    /// Check if player is hitting or not
    /// </summary>
    public static bool hit;
    private ParticleSystem Blood;
    private string anim;
    /// <summary>
    /// Create new zombie
    /// </summary>
    public ZombieChild Zombie;

    public FinalBossController Boss;
 
    void Update () {
        Move();
    }

    private int damagetoboss;
    void Start()
    {
         if (SettingController.Difficulty == 0)
        {
            damagetoboss = 7;
        } else if (SettingController.Difficulty == 1)
        {
            damagetoboss = 5;
        } else if (SettingController.Difficulty == 2)
        {
            damagetoboss = 1;
        }
        Blood = GetComponent<ParticleSystem>();
        Anim = GetComponent<Animator>();
        play = (Rigidbody2D) GameObject.Find("player").GetComponent<Rigidbody2D>();
        Player = GetComponent<Transform>();
        
    }

    public void createBoss()
    {

        Boss = (FinalBossController)GameObject.Find("FinalBoss").GetComponent<FinalBossController>();
    }
    /// <summary>
    /// Hit direction 0 = no hit, 1 = left hit, 2 = right hit.
    /// </summary>
    public int dirhitrange = 0;
    public LayerMask mask = 0;
    public LayerMask groundMask = 1 << 2;
    /// <summary>
    /// Position where enemy is dying.
    /// </summary>
    public static Vector3 diepos;

    public Vector2 legs = new Vector2(0,-50);
    /// <summary>
    /// controls moving player
    /// </summary>
    public float rayDistance = 2;
    public void Move () {

        //RAYCAST
        
	    Debug.DrawRay(transform.position, Vector3.right, Color.green, 2F);
        Debug.DrawRay(transform.position, Vector3.left, Color.blue, 2F);

        // Bit shift the index of the layer (8) to get a bit mask // This would cast rays only against colliders in layer 8, so we just inverse the mask.

        //layerMaskground = ~layerMaskground;

        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 3F, mask);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 3F, mask);

        
        
        
        
        if (hitright.collider != null)
        {
            dirhitrange = 2;
            Debug.Log("Ray Hit Right: " + hitright.transform.name);
            diepos = hitright.transform.position;
            Zombie = (ZombieChild)GameObject.Find(hitright.transform.name).GetComponent<ZombieChild>();
        } else if (hitleft.collider != null)
        {
            dirhitrange = 1;
            Debug.Log("Ray Hit Left: " + hitleft.transform.name);
            diepos = hitleft.transform.position;

            Zombie = (ZombieChild)GameObject.Find(hitleft.transform.name).GetComponent<ZombieChild>();
        }
        else
        {
            dirhitrange = 0;
            
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Anim != null && anim != "hit")
            {
                Anim.Play("Knight Animation");
                anim = "run";
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerHit();
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveright();
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { jump(); }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerHit();
            }

        }
        else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			moveleft();
		    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { jump(); }
            if (Input.GetKeyDown(KeyCode.Space)){
                playerHit();
            }
        }  else if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHit();
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump();
            }
        }
        else
        {
            if (Anim != null)
            {
                
            }
        }

    }

    public void moveleft()
    {
        transform.Translate(Vector2.right * playerspeed * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, 180);
        dirright = false;
        Debug.Log("Moving left");
		Debug.Log (transform.gameObject);
    }

    public void moveright()
    {
        transform.Translate(Vector2.right * playerspeed * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, 0);
        dirright = true;
        Debug.Log("Moving right");
		Debug.Log (transform.gameObject);

    }

    public void jump()
    {
        Debug.DrawRay(transform.position, legs, Color.red, rayDistance);

        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, legs, rayDistance, groundMask);
        
        if (hitdown.collider != null)
        {
            Debug.Log("Jump");
            Debug.Log(" Hitting: " + hitdown.collider.name);
            play.AddForce(new Vector2(0, 35), ForceMode2D.Impulse);
            
        }
        else
        {

            play.AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
            Debug.Log("Cant jump");
            
        }
      

    }
    /// <summary>
    /// Player hits.
    /// </summary>
    public void playerHit()
    {
        if (Anim != null)
        {
            Anim.Play("Hit");
            anim = "hit";
        }
        else { Debug.Log("Anim == null");}
        Debug.Log("Try to Hit");
        hit = true;
        if (dirright == true && dirhitrange == 2)
        {
            if (GameObject.Find("FinalBoss") != null)
            {
                Boss.Die(damagetoboss);
            }
            if (GameObject.Find("Zombie") != null)
            {
                Zombie.Die();
            }
            PointSystem.points += 1;
            Debug.Log("Hit right");

        }
        else if (dirright == false && dirhitrange == 1)
        {
            if (GameObject.Find("FinalBoss") != null)
            {
                Boss.Die(damagetoboss);
            }
            if (GameObject.Find("Zombie") != null)
            {
                Zombie.Die();
            }
            PointSystem.points += 1;
            Debug.Log("Hit left");
        } else
        {
            Debug.Log("Missed");
        }
        
        hit = false;
    }

   
}
