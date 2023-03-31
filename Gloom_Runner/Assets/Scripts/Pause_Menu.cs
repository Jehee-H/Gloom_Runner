using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    private Platformer.UI.MetaGameController metaGameController;
    public GameObject musicGameobject;
    private void Start()
    {
        metaGameController = GameObject.Find("Pause Menu").GetComponent<Platformer.UI.MetaGameController>();
    }

    public void Continue()
    {
        metaGameController.ToggleMainMenu(false);
    }

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
