using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;
    Vector3 camOffset = new Vector3(4f, 1.5f, -1f);


    private void Update()
    {
        this.transform.position = car.position + camOffset;
    }



}
