using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private Button startButton;
    private Button settingsButton;
    private Button exitButton;
    private Text menuText;
	public Sprite newgame1;
	public Sprite newgame2;

	// Use this for initialization
    /// <summary>
    /// Käynnistää objectit yms
    ///  </summary>
	void Start ()
	{
        //Lisätään objectit.
	    menuText = (Text) GameObject.Find("Text").GetComponent<Text> ();
	    startButton = (Button) GameObject.Find("Start_Button").GetComponent<Button>();
	    settingsButton = (Button)GameObject.Find("Settings_Button").GetComponent<Button>();
        exitButton = (Button)GameObject.Find("Exit_Button").GetComponent<Button>();
        // Lisään Kuuntelija
        startButton.onClick.AddListener(StartButtonClicked);
	    settingsButton.onClick.AddListener(SettingsButtonClicked);
        exitButton.onClick.AddListener(ExitButtonClicked);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void StartButtonClicked()
    {
        //menuText.text = "Start Clicked";
		//startButton.GetComponent<Image>().sprite = newgame1;
		//startButton.image.overrideSprite = newgame2;
		SceneManager.LoadScene("StartVideo");
    }
    void ExitButtonClicked()
    {
        Application.Quit();
    }

    void SettingsButtonClicked()
    {
		SceneManager.LoadScene("SettingsScene");
        
    }
}
