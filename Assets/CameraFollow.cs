using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player1Or2;
    public Vector3 offSet;

    void Update()
    {
        transform.position = Player1Or2.transform.position + offSet;
    }
}
