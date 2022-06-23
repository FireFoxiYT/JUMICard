using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLookScript : MonoBehaviour
{
    public Transform P1;
    public Transform P2;

    void Update()
    {
        Vector3 pos = (P1.position + P2.position) / 2;

        pos.y = 20;
        transform.position = pos;
    }
}
