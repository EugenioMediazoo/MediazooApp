﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGyro : MonoBehaviour
{
    GameObject camParent;

    void Start()
    {
        camParent = new GameObject("CamParent");
        camParent.transform.position = this.transform.position;
        this.transform.parent = camParent.transform;
        Input.gyro.enabled = true;
    }

    public void ReStart()
    {
        Input.gyro.enabled = false;
        camParent.transform.Rotate(0, 0, 0);
        this.transform.Rotate(0, 0, 0);
        Input.gyro.enabled = true;
    }

    void Update()
    {

        if (Input.gyro.enabled)
        {
            camParent.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
            this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        }
        else
            return;
    }
}
