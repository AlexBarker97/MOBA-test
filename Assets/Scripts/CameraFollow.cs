using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset;
    public bool followPlayer = true;
    public float cameraSpeed = 1.2f;
    private float smoothness = 0.5f;
    private float camFOV;
    private float scaledCamFOV;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float pctWidth = Screen.width / 40;
        float pctHeight = Screen.height / 40;
        float tenPctAv = (pctWidth + pctHeight) / 2;

        if (followPlayer == true)
        {
            //PLAYER FOLLOW
            Vector3 newPos = player.position + cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
        }
        else
        {
            //FREECAM
            camFOV = GetComponent<CameraScroll>().camFOV;
            scaledCamFOV = (camFOV - 10) / 90;

            if (Input.mousePosition.x < tenPctAv)   //CAMERA-LEFT
            {
                Vector3 newPos = transform.position - (Vector3.forward * cameraSpeed);
                transform.position = Vector3.Slerp(transform.position, newPos, scaledCamFOV);
            }
            if (Input.mousePosition.x > Screen.width - tenPctAv)    //CAMERA-RIGHT
            {
                Vector3 newPos = transform.position + (Vector3.forward * cameraSpeed);
                transform.position = Vector3.Slerp(transform.position, newPos, scaledCamFOV);
            }
            if (Input.mousePosition.y < tenPctAv)   //CAMERA-DOWN
            {
                Vector3 newPos = transform.position - (Vector3.left * cameraSpeed);
                transform.position = Vector3.Slerp(transform.position, newPos, scaledCamFOV);
            }
            if (Input.mousePosition.y > Screen.height - tenPctAv)   //CAMERA-UP
            {
                Vector3 newPos = transform.position + (Vector3.left * cameraSpeed);
                transform.position = Vector3.Slerp(transform.position, newPos, scaledCamFOV);
            }

        }
        if (Input.GetKeyDown(KeyCode.Space) && followPlayer == true)
        {
            followPlayer = false;
        } else if (Input.GetKeyDown(KeyCode.Space) && followPlayer == false)
        {
            followPlayer = true;
        }            
    }
}
