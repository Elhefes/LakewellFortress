using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource ZombieGrowlAudioSource;
    private AudioSource musicAudioSource;
    public static bool Sounds;

    private AudioSource videomusic;
	// Use this for initialization
	void Start () {
	    ZombieGrowlAudioSource = GetComponent<AudioSource>();
	    if (GameObject.Find("Music") != null)
	    {
	        musicAudioSource = (AudioSource) GameObject.Find("Music").GetComponent<AudioSource>();
	    }
	    videomusic = GetComponent<AudioSource>();
	    Sounds = SettingController.soundSettings;

	    if (Sounds == false && musicAudioSource != null)
	    {
	        musicAudioSource.enabled = !musicAudioSource.enabled;
	    }
	    if (Sounds == false && videomusic != null)
	    {
	        videomusic.enabled = !videomusic.enabled;
	    }
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    /// <summary>
    /// Play audio
    /// </summary>
    /// <param name="clips"></param>
    public void playZombieAudio()
    {
        
        
            Debug.Log("Playsound");
            
            if (Sounds)
        ZombieGrowlAudioSource.Play();

    }
}
