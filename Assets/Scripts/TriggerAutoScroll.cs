using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAutoScroll : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraController.isAutoScrolling = true;

        }
    }
}
