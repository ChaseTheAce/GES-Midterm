using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public static Checkpoint currentlyActiveCheckpoint;
    private SpriteRenderer spriteRenderer;
    private bool isActive;

    [SerializeField]
    private float activatedScale;
    [SerializeField]
    private float deactivatedScale;
    [SerializeField]
    private Color activatedColor;
    [SerializeField]
    private Color deactivatedColor;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = deactivatedColor;

        DeactivateCheckpoint();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isActive)
        {
            ActivateCheckpoint();

        }
    }

    private void DeactivateCheckpoint()
    {
        isActive = false;
        transform.localScale = transform.localScale * deactivatedScale;
        spriteRenderer.color = deactivatedColor;
    }

    private void ActivateCheckpoint()
    {

        if (currentlyActiveCheckpoint != null)
        {
            currentlyActiveCheckpoint.DeactivateCheckpoint();
        }

        isActive = true;
        currentlyActiveCheckpoint = this;
        transform.localScale = transform.localScale * activatedScale;
        spriteRenderer.color = activatedColor;
    }

}
