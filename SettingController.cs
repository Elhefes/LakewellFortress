using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingController : MonoBehaviour
{
    private Text sounds;
    private Toggle soundToggle;
	private Button backButton;
    /// <summary>
    /// 0 = easy, 1=hard 2=extreme
    /// </summary>
    public static int Difficulty;
    private Dropdown difficultyDropdown;
    /// <summary>
    /// if true, sounds are on, else sounds are off (changable in settings)
    /// </summary>
    public static bool soundSettings = true;
	// Use this for initialization
	void Start () {
	    
        soundToggle = (Toggle)GameObject.Find("ToggleSound").GetComponent<Toggle>();
	    sounds = (Text) GameObject.Find("LabelSound").GetComponent<Text>();
        soundToggle.onValueChanged.AddListener(SoundToggled);
		backButton = (Button) GameObject.Find("BackButton").GetComponent<Button>();
		backButton.onClick.AddListener(BackButtonClicked);
	    difficultyDropdown = (Dropdown)GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>();
        difficultyDropdown.onValueChanged.AddListener(delegate { DifficultyDropdownValueChanged(difficultyDropdown); });
	    difficultyDropdown.value = Difficulty;
	    difficultyDropdown.RefreshShownValue();
	    soundToggle.isOn = soundSettings;
	}

    private void DifficultyDropdownValueChanged(Dropdown target)
    {
        Debug.Log("Selected difficulty: " + target.value);
        Difficulty = target.value;
    }


    // Update is called once per frame
    void Update () {
	    
	}

	void BackButtonClicked()
	{
		SceneManager.LoadScene("MenuScene");
	}

    public static bool ReadSoundToggled(bool ison)
    {
        Debug.Log("Sounds read");
        return ison;
    }
    void SoundToggled(bool ison)
    {
        soundSettings = ison;
        ReadSoundToggled(ison);
        if (ison == true)
        {
            Debug.Log("Sounds");
            sounds.text = "Sounds On";
        }
        else
        {
            sounds.text = "Sounds Off";
        }
        
    }
}
