using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

    public GameObject continueButton;

    void Start()
    {
        if (!PlayerPrefs.HasKey("_progress_")) {
            continueButton.gameObject.SetActive(false);
        }
    }

    public void Continue()
    {
        
    }
    
    public void Load(int level)
    {
        PlayerPrefs.SetString("_progress_", level.ToString());
    }

    public void NewGame()
    {
        PlayerPrefs.SetString("_progress_", "1");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
