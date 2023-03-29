using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory_Menu : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("_progress_", (SceneManager.GetActiveScene().buildIndex + 1).ToString());
    }
    
    public void Continue()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Quit();
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
