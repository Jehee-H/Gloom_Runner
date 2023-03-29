using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinScoreManager : MonoBehaviour
{
    public TMP_Text textCoinScore;
    public float coinScore;
    int[] coinTotals = { 0, 3, 3, 1, 1, 1, 1, 1 };

    public GameObject gameController;
    Platformer.UI.MetaGameController metaGameController;

    void Start()
    {
        metaGameController = gameController.GetComponent<Platformer.UI.MetaGameController>();

        coinScore = 0f;
        textCoinScore.text = "Coins: " + coinScore.ToString() + "/" + coinTotals[SceneManager.GetActiveScene().buildIndex].ToString();

        Debug.Log(metaGameController == null);
        Debug.Log(gameController);
    }

    void Update()
    {
        textCoinScore.text = "Coins: " + coinScore.ToString() + "/" + coinTotals[SceneManager.GetActiveScene().buildIndex].ToString();

        if (coinScore >= coinTotals[SceneManager.GetActiveScene().buildIndex])
        {
            metaGameController.ToggleVictoryMenu(true);
            ///GameController.GetComponent<MetaGameController>().ToggleVictoryMenu(true);
        }
    }
}
