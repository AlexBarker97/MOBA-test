using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset;
    public bool toggled = true;

    [Range(0.01f, 1.0f)]
    public float smoothness = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (toggled == true)
        {
            Vector3 newPos = player.position + cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
        }
        else
        {
            // freecam
        }
        if (Input.GetKeyDown(KeyCode.Space) && toggled == true)
        {
            toggled = false;
        } else if (Input.GetKeyDown(KeyCode.Space) && toggled == false)
        {
            toggled = true;
        }            
    }
}
