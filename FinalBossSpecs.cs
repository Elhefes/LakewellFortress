using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Creating all unity things. Can be called.
/// </summary>
public class FinalBossSpecs : MonoBehaviour
{
    public Animator anim;
    public PolygonCollider2D BossCollider2D;
    public Rigidbody2D BossRigidbody2D;
    public ParticleSystem BossBlood;
    public AudioSource BossScreamAudioSource;
    public AudioClip AudioClip;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        BossCollider2D = GetComponent<PolygonCollider2D>();
        BossRigidbody2D = GetComponent<Rigidbody2D>();
        BossBlood = GetComponent<ParticleSystem>();
        BossScreamAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void animPlay(string animation)
    {

        anim.Play(animation);

    }

    public void playAudio()
    {
        if (AudioClip != null)
        {
            BossScreamAudioSource.clip = AudioClip;
            BossScreamAudioSource.Play();
        }
        else { Debug.Log("AudioClip" + AudioClip + ", cannot be found"); }
    }


}
