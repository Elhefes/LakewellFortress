using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D play;
	private bool onGround;
    public Transform Character;
    public Animator Anim;
    public Transform Player;
    private Vector2 directionOfCharacter;
    private Vector2 playerV;
    private bool dirright = true;
    
    
    void Update () {
        Move();
        
    }
    
    void Start()
    {
        


        Anim = GetComponent<Animator>();
        play = (Rigidbody2D) GameObject.Find("placeholderPlayer").GetComponent<Rigidbody2D>();
        Player = (Transform)GameObject.Find("placeholderPlayer").GetComponent<Transform>();
        Character = (Transform)GameObject.Find("Zombie").GetComponent<Transform>();
        
        directionOfCharacter = Character.transform.position - transform.position;
    }
    // 0 = not either 1 = left, 2 = right.
    public int dirhitrange = 0;
    public LayerMask mask = 0;
    public static Vector3 diepos;
    void Move () {

        //RAYCAST
	    Debug.DrawRay(transform.position, Vector3.right, Color.green, 2F);
        Debug.DrawRay(transform.position, Vector3.left, Color.blue, 2F);
        // Bit shift the index of the layer (8) to get a bit mask // This would cast rays only against colliders in layer 8, so we just inverse the mask.
        int layerMask = 1 << 2; layerMask = ~layerMask;
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 2F, layerMask);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 2F, layerMask);
        if (hitright.collider != null)
        {
            dirhitrange = 2;
            Debug.Log("Ray Hit Right: " + hitright.transform.name);
            diepos = hitright.transform.position;
        } else if (hitleft.collider != null)
        {
            dirhitrange = 1;
            Debug.Log("Ray Hit Left: " + hitleft.transform.name);
            diepos = hitleft.transform.position;
        }
        else
        {
            dirhitrange = 0;
            
        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            play.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 7f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            dirright = true;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { jump(); }

        }
        else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector2.right * 7f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0,180);
		    dirright = false;
		    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { jump(); }
        }  else if (Input.GetKeyDown(KeyCode.Space))
		{
		   playerHit();
		    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { jump(); }
        }

    }

    void jump()
    {
        play.AddForce(new Vector2(0,15), ForceMode2D.Impulse);
    }

    void playerHit()
    {
        Debug.Log("Try to Hit");
        
        if (dirright == true && dirhitrange == 2)
        {
            ZombieController.die = 1;
            PointSystem.points += 1;
            Debug.Log("Hit right");

        }
        else if (dirright == false && dirhitrange == 1)
        {

            ZombieController.die = 1;
            PointSystem.points += 1;
            Debug.Log("Hit left");
        } else
        {
            Debug.Log("Missed");
        }
        Anim.Play("Hit");
      
    }
}
