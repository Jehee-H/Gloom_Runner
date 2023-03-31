using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public GameObject gameController;
    Platformer.UI.MetaGameController metaGameController;
    private AudioSource source;
    public AudioClip deadSound;


    void Awake()
    {
        metaGameController = gameController.GetComponent<Platformer.UI.MetaGameController>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            source.PlayOneShot(deadSound);
            metaGameController.ToggleDefeatMenu(true);
        }
    }
}
