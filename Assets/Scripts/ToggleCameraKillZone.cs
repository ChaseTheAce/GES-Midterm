using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCameraKillZone : MonoBehaviour {

    private void Update()
    {
        if (CameraController.isAutoScrolling)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
