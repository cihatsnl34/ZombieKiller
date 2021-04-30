using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float sensivity = 3;
    void Start()
    {
        
    }

  
    void Update()
    {
        RotatePlayerBody();
    }
    private float rotateX = 0;
    private float rotateY = 0;
    private void RotatePlayerBody()
    {
        rotateX += sensivity * Input.GetAxis("Mouse X");
        rotateY += sensivity * Input.GetAxis("Mouse Y") * -1;
        rotateY = Mathf.Clamp(rotateY, -80, 80);
        transform.eulerAngles = new Vector3(rotateY, rotateX, 0);
    }
}
