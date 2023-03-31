using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighscoreList : MonoBehaviour
{
    public TMP_Text textHighscores;
    public string highscore1;
    public string highscore2;
    public string highscore3;
    public string highscore4;
    public string highscore5;
    public string highscore6;
    public string highscore7;

    public string highscoreHolder1;
    public string highscoreHolder2;
    public string highscoreHolder3;
    public string highscoreHolder4;
    public string highscoreHolder5;
    public string highscoreHolder6;
    public string highscoreHolder7;

    void Start()
    {
        if (!PlayerPrefs.HasKey("_highscore1_")) { highscore1 = "---"; }
        else { highscore1 = PlayerPrefs.GetString("_highscore1_"); }

        if (!PlayerPrefs.HasKey("_highscore2_")) { highscore2 = "---"; }
        else { highscore2 = PlayerPrefs.GetString("_highscore2_"); }

        if (!PlayerPrefs.HasKey("_highscore3_")) { highscore3 = "---"; }
        else { highscore3 = PlayerPrefs.GetString("_highscore3_"); }

        if (!PlayerPrefs.HasKey("_highscore4_")) { highscore4 = "---"; }
        else { highscore4 = PlayerPrefs.GetString("_highscore4_"); }

        if (!PlayerPrefs.HasKey("_highscore5_")) { highscore5 = "---"; }
        else { highscore5 = PlayerPrefs.GetString("_highscore5_"); }

        if (!PlayerPrefs.HasKey("_highscore6_")) { highscore6 = "---"; }
        else { highscore6 = PlayerPrefs.GetString("_highscore6_"); }

        if (!PlayerPrefs.HasKey("_highscore7_")) { highscore7 = "---"; }
        else { highscore7 = PlayerPrefs.GetString("_highscore7_"); }


        if (!PlayerPrefs.HasKey("_highscoreHolder1_")) { highscoreHolder1 = "---"; }
        else { highscoreHolder1 = PlayerPrefs.GetString("_highscoreHolder1_"); }

        if (!PlayerPrefs.HasKey("_highscoreHolder2_")) { highscoreHolder2 = "---"; }
        else { highscoreHolder2 = PlayerPrefs.GetString("_highscoreHolder2_"); }

        if (!PlayerPrefs.HasKey("_highscoreHolder3_")) { highscoreHolder3 = "---"; }
        else { highscoreHolder3 = PlayerPrefs.GetString("_highscoreHolder3_"); }

        if (!PlayerPrefs.HasKey("_highscoreHolder4_")) { highscoreHolder4 = "---"; }
        else { highscoreHolder4 = PlayerPrefs.GetString("_highscoreHolder4_"); }

        if (!PlayerPrefs.HasKey("_highscoreHolder5_")) { highscoreHolder5 = "---"; }
        else { highscoreHolder5 = PlayerPrefs.GetString("_highscoreHolder5_"); }

        if (!PlayerPrefs.HasKey("_highscoreHolder6_")) { highscoreHolder6 = "---"; }
        else { highscoreHolder6 = PlayerPrefs.GetString("_highscoreHolder6_"); }

        if (!PlayerPrefs.HasKey("_highscoreHolder7_")) { highscoreHolder7 = "---"; }
        else { highscoreHolder7 = PlayerPrefs.GetString("_highscoreHolder7_"); }


        textHighscores.text =
            "Level 1: " + highscore1 + "\n" + highscoreHolder1 + "\n\n" +
            "Level 2: " + highscore2 + "\n" + highscoreHolder2 + "\n\n" +
            "Level 3: " + highscore3 + "\n" + highscoreHolder3 + "\n\n" +
            "Level 4: " + highscore4 + "\n" + highscoreHolder4 + "\n\n" +
            "Level 5: " + highscore5 + "\n" + highscoreHolder5 + "\n\n" +
            "Level 6: " + highscore6 + "\n" + highscoreHolder6 + "\n\n" +
            "Level 7: " + highscore7 + "\n" + highscoreHolder7;
    }

    void Update()
    {
        
    }
}
