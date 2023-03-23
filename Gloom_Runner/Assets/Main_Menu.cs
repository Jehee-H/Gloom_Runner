using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("_last_scene_"));
    }
    
    public void Load(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
