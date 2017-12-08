using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerControler : MonoBehaviour
{

    
    
    public Text currentMinutes;
    public Text currentSeconds;
    public Text totalMinutes;
    public Text totalSeconds;
    public static double seconds;
    private VideoPlayer videoPlayer;
    private int videoClipIndex;
    private double cliplent;
    /// <summary>
    /// 0=nothing done 1= set active 2= do nothing anymore 3=set unactive 4=destroy
    /// </summary>
    private int check;

    private PrintName printa;
    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Use this for initialization
    void Start()
    {
        printa = (PrintName) GameObject.Find("Text").GetComponent<PrintName>();
		seconds = 0.0;
      	cliplent = 40;
        check = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
		
        if (videoPlayer.isPlaying)
        {
            SetCurrentTimeUI();
        }
        if (cliplent <= (videoPlayer.time))
        {
            SceneManager.LoadScene("Level1_Scene");
        }
        seconds = ((double)videoPlayer.time % 60);

        if (seconds >= 23.1 && check == 0)
        {
            printa.TimeShow();
            check = 1;
        } else if (seconds >= 28.1 && check == 1)
        {
            printa.TimeHide();
            check = 2;
        }
        
    }

    

    

    void SetCurrentTimeUI()
    {
        string minutes = Mathf.Floor((int)videoPlayer.time / 60).ToString("00");
        string seconds = ((double)videoPlayer.time % 60).ToString("00.000");

        Debug.Log("Playing Minutes:" + minutes + "Seconds: " + seconds);
    }

    void SetTotalTimeUI()
    {
        string minutes = Mathf.Floor((int)videoPlayer.clip.length / 60).ToString("00");
        string seconds = ((double)videoPlayer.clip.length % 60).ToString("00.000");

        Debug.Log("Total Minutes:" + minutes + "Seconds: " + seconds);
    }

    double CalculatePlayedFraction()
    {
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
        return fraction;
    }
}