using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    private int cherries = 0;
    private int bananas = 0;
    [SerializeField] private Text cherriesText;

    [SerializeField] private Text bananasText;

    [SerializeField] private AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;

        }

        if (collision.gameObject.CompareTag("Banane"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            bananas++;
            bananasText.text = ""+bananas;

        }
    }
}

