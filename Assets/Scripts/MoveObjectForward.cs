using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectForward : MonoBehaviour {

    [SerializeField]
    float moveSpeed = .5f;
    [SerializeField]
    float originX;
    [SerializeField]
    float delayTime = 3f;

    SpriteRenderer spriteRenderer;
    Hazard hazard;
    BoxCollider2D boxCollider;
    bool shouldMove;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        hazard = GetComponent<Hazard>();
        hazard.enabled = false;
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {
        if (shouldMove && CameraController.isAutoScrolling == true)
        {
            MoveForward();
        }
        else if (shouldMove && CameraController.isAutoScrolling == false)
        {
            moveSpeed = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Delay());


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            boxCollider.isTrigger = true;
            hazard.enabled = false;
            shouldMove = false;
            transform.position = new Vector3(originX, transform.position.y, transform.position.z);
        }
       
    }


    private void MoveForward()
    {
        Vector3 newPos = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
        transform.position = newPos;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        spriteRenderer.enabled = true;
        boxCollider.isTrigger = false;
        hazard.enabled = true;
        shouldMove = true;

    }
}

