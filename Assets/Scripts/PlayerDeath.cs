using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public int playerHealth = 3;
    public TextMeshProUGUI healthNumber;
    public GameObject deathScreen;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerHealth.ToString();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (playerHealth == 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
            StartCoroutine(ShowPopupWithDelay(2f));
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            playerHealth--;
            healthNumber.text = playerHealth.ToString();
        }
        if(collision.gameObject.CompareTag("Spikes"))
        {
            playerHealth = 0;
            healthNumber.text = playerHealth.ToString();
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
            StartCoroutine(ShowPopupWithDelay(2f));
        }
    }

    IEnumerator ShowPopupWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        deathScreen.SetActive(true);
        Time.timeScale = 1;
    }

  

}
