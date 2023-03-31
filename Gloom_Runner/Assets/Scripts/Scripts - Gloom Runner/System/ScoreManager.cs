using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public float score;

    public GameObject ui;
    TimeManager timeManager;

    void Start()
    {

        if (!PlayerPrefs.HasKey("_highscore" + SceneManager.GetActiveScene().buildIndex.ToString() + "_"))
        {
            PlayerPrefs.SetString("_highscore" + SceneManager.GetActiveScene().buildIndex.ToString() + "_", 9999999f.ToString());
        }

        timeManager = ui.GetComponent<TimeManager>();
        score = Mathf.Round(timeManager.timer * 100f) / 100f;

        if (float.Parse(PlayerPrefs.GetString("_highscore" + SceneManager.GetActiveScene().buildIndex.ToString() + "_")) < score)
        {
            textScore.text = "Your Time: " + score.ToString() + "\nHighscore: " + PlayerPrefs.GetString("_highscore" + SceneManager.GetActiveScene().buildIndex.ToString() + "_");
        }
        else
        {
            PlayerPrefs.SetString("_highscore" + SceneManager.GetActiveScene().buildIndex.ToString() + "_", score.ToString());
            PlayerPrefs.SetString("_highscoreHolder" + SceneManager.GetActiveScene().buildIndex.ToString() + "_", PlayerPrefs.GetString("_hooman_Name_"));
            textScore.text = "Your Time: " + score.ToString() + "\nNew Highscore!!!";
        }
    }

    void Update()
    {

    }
}
