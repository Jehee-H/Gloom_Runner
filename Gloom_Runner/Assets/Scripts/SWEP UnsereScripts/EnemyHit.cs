using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public GameObject gameController;
    Platformer.UI.MetaGameController metaGameController;


    void Awake()
    {
        metaGameController = gameController.GetComponent<Platformer.UI.MetaGameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            metaGameController.ToggleDefeatMenu(true);
        }
    }
}
