using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    Transform objectToFollow;

    [SerializeField]
    float cameraFollowSpeed = 5;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    [SerializeField]
    float scrollSpeed = 1;

    public static bool isAutoScrolling = false;

    float zOffset = -10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AutoScrollCheck();
	}

    void AutoScrollCheck()
    {
        if (isAutoScrolling == true)
        {
            AutoScroll();
        }
        else
        {
            FollowObject();
        }
    }

    void AutoScroll()
    {
        Vector3 newPosition = new Vector3(transform.position.x + scrollSpeed, objectToFollow.position.y + yOffset, zOffset);
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime);
    }

    void FollowObject()
    {
        Vector3 newPosition = new Vector3(objectToFollow.position.x + xOffset, objectToFollow.position.y + yOffset, zOffset);
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAutoScrolling = true;

        }
    }
}
