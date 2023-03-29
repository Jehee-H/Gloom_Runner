using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void Begin(int character)
    {
        if (nameInput.text.ToString() == "")
        {
            PlayerPrefs.SetString("_hooman_Name_", "Anonymous");
        }
        else
        {
            PlayerPrefs.SetString("_hooman_Name_", nameInput.text.ToString());
        }

        PlayerPrefs.SetInt("_character_", character);

        SceneManager.LoadScene(int.Parse(PlayerPrefs.GetString("_progress_")));
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
