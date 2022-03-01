using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSlider : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void LateUpdate()
    {
        //newLocalRotation = newWorldRotation * Quaternion.Inverse(transform.parent.rotation);

        transform.LookAt(player.transform, Vector3.left);
        transform.Rotate(0, 180, 0);
    }
}
