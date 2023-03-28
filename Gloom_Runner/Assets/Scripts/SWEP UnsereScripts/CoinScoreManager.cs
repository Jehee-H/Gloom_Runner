using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinScoreManager : MonoBehaviour
{
    public TMP_Text textCoinScore;
    public float coinScore;
    int[] coinTotals = { 0, 3, 3, 3, 3, 3, 3, 3 };

    void Start()
    {
        coinScore = 0f;
        textCoinScore.text = "Coins: " + coinScore.ToString() + "/" + coinTotals[SceneManager.GetActiveScene().buildIndex].ToString();
    }

    void Update()
    {
        textCoinScore.text = "Coins: " + coinScore.ToString() + "/" + coinTotals[SceneManager.GetActiveScene().buildIndex].ToString();
    }
}
