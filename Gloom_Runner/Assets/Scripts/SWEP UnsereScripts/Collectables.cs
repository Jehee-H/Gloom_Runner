using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private CoinScoreManager coinScoreManager;
    private AudioSource source;
    public AudioClip ring;

    private void Start()
    {
        coinScoreManager = GameObject.Find("UI").GetComponent<CoinScoreManager>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {

            source.PlayOneShot(ring);

            Debug.Log("IchWarHier");

            coinScoreManager.coinScore += 1f;
            Destroy(collision.gameObject);
        }
    }
}
