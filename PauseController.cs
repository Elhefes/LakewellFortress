using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseController : MonoBehaviour
{
    private Button continueButton;
    private Button exitButton;
    private Button restartButton;

    private Text optionsText;
    // Use this for initialization
    
    
        
    public GameObject[] pauseObjects;
	// Use this for initialization
	void Start () {
	    Time.timeScale = 1;
	    pauseObjects = GameObject.FindGameObjectsWithTag("PauseOnly");
	    hidePaused();
	   
        restartButton = (Button)GameObject.Find("RestartButton").GetComponent<Button>();
	    exitButton = (Button)GameObject.Find("Exit").GetComponent<Button>();
	    continueButton = (Button)GameObject.Find("Continue").GetComponent<Button>();
	    optionsText = (Text)GameObject.Find("Difficulty Text").GetComponent<Text>();

        continueButton.onClick.AddListener(pauseControl);
	    exitButton.onClick.AddListener(Reload);
	    restartButton.onClick.AddListener(pauseControl);
    }
	
	// Update is called once per frame
	void Update () {
        //optionsText.text = "Difficulty: " + SettingController.Difficulty
	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        if (Time.timeScale == 1)
	        {
	            Time.timeScale = 0;
	            showPaused();
	        }
	        else if (Time.timeScale == 0)
	        {
	            Debug.Log("high");
	            Time.timeScale = 1;
	            hidePaused();
	        }
	    }
    }
    //Reloads the Level
    public void Reload()
    {
        Debug.Log("Reload");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    //controls the pausing of the scene
    public void pauseControl()
    {
        Debug.Log("PauseControl");
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }
    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
