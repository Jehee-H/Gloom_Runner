using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private CoinScoreManager coinScoreManager;

    private void Start()
    {
        coinScoreManager = GameObject.Find("UI").GetComponent<CoinScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("IchWarHier");

            coinScoreManager.coinScore += 1f;
            Destroy(collision.gameObject);
        }
    }
}
