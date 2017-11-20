using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAutoScroll : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraController.isAutoScrolling = false;

        }
    }
}

