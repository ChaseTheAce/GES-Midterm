using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    static int coinCount = 0;

    private Text coinCountText;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    

    private void Start()
    {
        coinCountText = GameObject.Find("coinCountText").GetComponent<Text>();
        coinCountText.text = "Coins: " + coinCount;
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            coinCount++;
            coinCountText.text = "Coins: " + coinCount;
            Debug.Log("Touched the Coin! coinCount is " + coinCount);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            //Destroy(gameObject);

        }

        
    }
}
