using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
    private Button RestartButton;
    private Button MenuButton;
    
    // Use this for initialization
    void Start () {
        RestartButton = (Button)GameObject.Find("Restart").GetComponent<Button>();
        RestartButton.onClick.AddListener(RestartButtonClicked);
        MenuButton = (Button)GameObject.Find("Menu").GetComponent<Button>();
        MenuButton.onClick.AddListener(MenuButtonClicked);
    }

    public void RestartButtonClicked()
    {
        PointSystem.Reset();
       
        SceneManager.LoadScene(PointSystem.scene);
    }

   public void MenuButtonClicked()
   {
       PointSystem.Reset();
        SceneManager.LoadScene("MenuScene");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
