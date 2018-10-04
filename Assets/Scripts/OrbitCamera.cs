using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField]
    private Transform targert;

    public float rotSpeed = 1.5f;

    private float rotY;
    private Vector3 offset;

    void Start()
    {
        rotY = transform.eulerAngles.y;
        offset = targert.position - transform.position;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0)
        {
            rotY += horInput * rotSpeed;
        }
        else
        {
            rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }

        Quaternion rotation = Quaternion.Euler(0, rotY, 0);
        transform.position = targert.position - rotation * offset;
        transform.LookAt(targert);
    }
}