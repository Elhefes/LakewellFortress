using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backbuttonvictory : MonoBehaviour {

    private Button backButton;
    // Use this for initialization
    void Start () {
        backButton = (Button)GameObject.Find("BackButton").GetComponent<Button>();
        backButton.onClick.AddListener(BackButtonClicked);
    }
    void BackButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
