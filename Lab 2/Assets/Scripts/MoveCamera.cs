using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    void Update()
    {
        //moves camera with player
        transform.position = cameraPosition.position;
    }
}
