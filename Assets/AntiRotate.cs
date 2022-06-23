using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRotate : MonoBehaviour
{
    public float rotationAmount;
    void Update()
    {
        if(transform.rotation.x < 0) {
            //transform.rotation = Quaternion.Euler(0, transform.rotation.y + rotationAmount, 0);
        }
        if(transform.rotation.x > 0) {
            //transform.rotation = Quaternion.Euler(0, transform.rotation.y - rotationAmount, 0);
        }
    }
}
