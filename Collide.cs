using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    private static string level;

    // Use this for initialization
	void OnCollisionEnter2D(Collision2D coll)
	{
	    Scene scene = SceneManager.GetActiveScene();
        //jos while käytössä tarkistaa jatkuvasti, nyt tarkistaa osuman. 
        //Ei voi käyttää poislähtiessä eli vain kun osuu pelaajaan tekee jotain    
        //kun osuu pelaajaan

        if (coll.gameObject.tag == "Player") {
			Debug.Log ("hi");
            if (level == "Fortress")
            {
                SceneManager.LoadScene("Fortress2");
            } else
            {
                level = "Fortress";
                SceneManager.LoadScene("Fortress");
            }
                
            }
        }
	
}
