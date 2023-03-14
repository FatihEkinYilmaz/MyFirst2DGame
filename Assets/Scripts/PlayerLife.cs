using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator anim;

    [SerializeField] private AudioSource deathSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            deathSound.Play();
        }
    }

    private void Die()
    {
        playerRb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
