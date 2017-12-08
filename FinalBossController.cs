using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FinalBossController : MonoBehaviour
{

    public Transform Character; // Target Object to follow
    public float speed = 0.1F; // Enemy speed
    public Vector2 directionOfCharacter;
    public bool challenged = true;// If the enemy is Challenged to follow by the player
    public FinalBossSpecs BossAnimation;
    public static int Bosshealth = 100;
    private bool dead;
    public float movespeed;
    /// <summary>
    /// is the boss moving? 1== yes 0== no
    /// </summary>
    private int move = 1;
    public PlayerController asdasd;
    public Text BossHealth;
    public Image HealthBar;
    public float cur_Health;
    public float max_Health = 100f;
    private AudioSource ZombieGrowlAudioSource;
    private int Difficultydamage;
    public Rigidbody2D play;


    void Start()
    {
        PlayerController.playerspeed = 15f;
        play = GetComponent<Rigidbody2D>();
        HealthBar = (Image) GameObject.Find("HealthBar").GetComponent<Image>();
        BossHealth = (Text) GameObject.Find("BossHealth").GetComponent<Text>();
        BossAnimation = GetComponent<FinalBossSpecs>();
        asdasd = (PlayerController) GameObject.Find("player").GetComponent<PlayerController>();
        Debug.Log("Created Boss");
        asdasd.createBoss();
        Character = (Transform)GameObject.Find("player").GetComponent<Transform>();
        ZombieGrowlAudioSource = GetComponent<AudioSource>();


        if (SettingController.Difficulty == 0)
        {
            movespeed = 7f;
            Difficultydamage = 25;
        } else if (SettingController.Difficulty == 1)
        {
            movespeed = 15f;
            Difficultydamage = 25;
        } else if (SettingController.Difficulty == 2)
        {
            movespeed = 50f;
            Difficultydamage = 20;
        }
    }

    void Update()
    {
        if (move == 2)
        {
            if (play != null)
            {
                play.AddForce(new Vector2(0, 50), ForceMode2D.Impulse);
            }
            move = 1;
        }
        if (challenged && dead == false)
        {
            directionOfCharacter = Character.transform.position - transform.position;
            directionOfCharacter = directionOfCharacter.normalized; // Get Direction to Move Towards
            //transform.Translate(directionOfCharacter * 0.1F);


        }

        if (move == 1 && directionOfCharacter.GetHashCode() < 0 && dead == false)
        {
            transform.eulerAngles = new Vector2(0, 0);
            transform.Translate(Vector2.right * movespeed * Time.deltaTime);
        }
        else if (move == 1 && dead == false)
        {
            transform.eulerAngles = new Vector2(0, 180);
            transform.Translate(Vector2.right * movespeed * Time.deltaTime);
        }
        BossHealth.text = "Boss Health: " + Bosshealth;
        
            
    }



    // Will be triggered as soon as player would touch the Enemy Object

    void OnCollisionEnter2D(Collision2D coll)
    {
        //jos while käytössä tarkistaa jatkuvasti, nyt tarkistaa osuman. 
        //Ei voi käyttää poislähtiessä eli vain kun osuu pelaajaan tekee jotain    
        //kun osuu pelaajaan

        if (coll.gameObject.tag == "Player" && dead == false && move == 1)
        {
            Debug.Log("Osuma oikea!!!!!!!");
            
            PointSystem.health -= Difficultydamage;

            BossAnimation.animPlay("AttackaAnim");
            move = 0;
            StartCoroutine(Wait());
            
        }
        else if (dead == false)
        { //kun ei osu
            if (BossAnimation.anim != null)
                BossAnimation.animPlay("WalkAnimation");


        }

    }

    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(5);
        move = 2;
    }
    public void Die(int damage=10)
    {


        if (SoundController.Sounds)
        {
            ZombieGrowlAudioSource.Play();
        }
        Bosshealth -= damage;
        changehealth(Bosshealth);
        BossAnimation.animPlay("HurtAnim");

        if (Bosshealth <= 0)
        {
            BossDieReal();
        }


    }

    void SetHealth(float health)
    {

        HealthBar.transform.localScale = new Vector3(Mathf.Clamp(health, 0f, 1f),
            HealthBar.transform.localScale.y,
            HealthBar.transform.localScale.z);


    }
    void changehealth(float healthvalue)
    {
        if (cur_Health == healthvalue)
            return;
        if (healthvalue > max_Health)
            cur_Health = max_Health;
        else if (healthvalue >= 0)
            cur_Health = healthvalue;
        else
            cur_Health = 0;
        float calc_Health = cur_Health / max_Health;
        SetHealth(calc_Health);
    }
    void BossDieReal()
    {
        BossAnimation.animPlay("BossDie");

        dead = true;
        PointSystem.points += 1;
        Debug.Log("Boss is dead");
        if (BossAnimation.BossCollider2D != null)
        {
            Destroy(BossAnimation.BossCollider2D);
        }
        if (BossAnimation.BossRigidbody2D != null)
        {
            Destroy(BossAnimation.BossRigidbody2D);
        }
        if (BossAnimation.BossBlood != null)
        {
            BossAnimation.BossBlood.Play();
        }
        SceneManager.LoadScene("victory");
    }


}





