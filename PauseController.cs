using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseController : MonoBehaviour
{
    private Button continueButton;
    private Button exitButton;
    private Button restartButton;
	public static bool paused;
    /// <summary>
    /// Pausenow. If set to 0 = do nothing, 1 = pause, 2 = unpause.
    /// </summary>
    public static int pausenow;
    private Text optionsText;
    // Use this for initialization
	public GameObject[] mobileObjects;
    
        
    public GameObject[] pauseObjects;
	// Use this for initialization
	void Start ()
	{
		mobileObjects = GameObject.FindGameObjectsWithTag("MobileControls");
	    pausenow = 0;
	    Time.timeScale = 1;
	    pauseObjects = GameObject.FindGameObjectsWithTag("PauseOnly");
	    
	   
        restartButton = (Button)GameObject.Find("RestartButton").GetComponent<Button>();
	    exitButton = (Button)GameObject.Find("Exit").GetComponent<Button>();
	    continueButton = (Button)GameObject.Find("Continue").GetComponent<Button>();

        continueButton.onClick.AddListener(pauseControl);
	    exitButton.onClick.AddListener(LoadLevel);
	    restartButton.onClick.AddListener(Reload);
	    hidePaused();
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
				foreach (GameObject a in mobileObjects)
				{
					a.SetActive(false);
				}
			
	        }
	        else if (Time.timeScale == 0)
	        {
	            Debug.Log("high");
	            Time.timeScale = 1;
	            hidePaused();
	            MobileControl.Continue = true;
				foreach (GameObject a in mobileObjects)
				{
					a.SetActive(true);
				}
            }
	    }
	    if (pausenow == 1)
	    {
	        Time.timeScale = 0;
            showPaused();
	        pausenow = 0;
	        MobileControl.Continue = false;
	    } else if (pausenow == 2)
	    {
	        Time.timeScale = 1;
	        hidePaused();
	        pausenow = 0;
	        MobileControl.Continue = true;
        }
	    
    }
    //Reloads the Level
    public void Reload()
    {
        PointSystem.Reset();
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
            Debug.Log("Pause nabbula");
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
            Debug.Log("Continue nabbula");
        }
    }
    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
			paused = true;
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
			paused = false;
            MobileControl.Continue = true;
        }
    }

    //loads inputted level
    public void LoadLevel()
    {
        PointSystem.Reset();
        SceneManager.LoadScene("MenuScene");
    }
}
