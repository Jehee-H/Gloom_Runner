using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    private Platformer.UI.MetaGameController metaGameController;

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
        SceneManager.LoadScene(0);
    }
}
