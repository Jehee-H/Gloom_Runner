using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetString("_progress_", (SceneManager.GetActiveScene().buildIndex + 1).ToString());
    }

    public GameObject musicGameobject;


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        destroyMusicBox();
        SceneManager.LoadScene(0);
    }

    public void destroyMusicBox()
    {
        Destroy(GameObject.Find("MusicObject"));

    }
}
