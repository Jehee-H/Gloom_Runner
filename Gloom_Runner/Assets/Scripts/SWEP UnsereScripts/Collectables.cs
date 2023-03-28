using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
<<<<<<< HEAD
=======
    private CoinScoreManager coinScoreManager;

    private void Start()
    {
        coinScoreManager = GameObject.Find("UI").GetComponent<CoinScoreManager>();
    }
>>>>>>> dominik-branch

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
<<<<<<< HEAD
            Debug.Log("Nutte");
            Destroy(collision.gameObject);

        }
    }

=======
            Debug.Log("IchWarHier");

            coinScoreManager.coinScore += 1f;
            Destroy(collision.gameObject);
        }
    }
>>>>>>> dominik-branch
}
