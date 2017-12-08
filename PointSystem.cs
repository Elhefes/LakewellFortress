
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public static int health = 100;
    public static int points;
    public Text healthText;
    public Text pointsText;
    public static string scene;
    
    // Use this for initialization
    void Start ()
	{
	   healthText = (Text) GameObject.Find("HealthText").GetComponent<Text>();
	   pointsText = (Text)GameObject.Find("PointsText").GetComponent<Text>();
	    
    }

    
    // Update is called once per frame
    void Update () {
        
        healthText.text = "Health: " + health;
	    pointsText.text = "Points: " + points;
        Scene SScene = SceneManager.GetActiveScene();
        if (health <= 0)
        {
            scene = SScene.name;
    SceneManager.LoadScene("PlayerDie");
            
	    }
	}

    public static void Reset()
    {
        health = 100;
        points = 0;
        FinalBossController.Bosshealth = 100;
    }
}
