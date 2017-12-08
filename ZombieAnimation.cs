using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Creating all unity things. Can be called.
/// </summary>
public class ZombieAnimation : MonoBehaviour {
    public Animator anim;
    public PolygonCollider2D ZombieCollider2D;
    public Rigidbody2D ZombieRigidbody2D;
    public ParticleSystem ZombieBlood;
    

    // Use this for initialization
    void Start () {
	    anim = gameObject.GetComponent<Animator>();
        ZombieCollider2D = GetComponent<PolygonCollider2D>();
        ZombieRigidbody2D = GetComponent<Rigidbody2D>();
        ZombieBlood = GetComponent<ParticleSystem>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void animPlay(string animation)
    {
       
           anim.Play(animation);
        
    }

    

   
}
