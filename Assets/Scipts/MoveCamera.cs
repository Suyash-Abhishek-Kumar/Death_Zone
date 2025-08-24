using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Reference")]
    public Transform cameraPosition;

    void Update()
    {
        if (cameraPosition != null)
        {
            transform.position = cameraPosition.position;
        }
    }
}
