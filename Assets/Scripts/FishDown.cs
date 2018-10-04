using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FishDown : MonoBehaviour
{
    public float gravity = -9.8f;
    public float terminalVelocity = -10f;
    public float minFall = -1.5f;

    private float vertSpeed;
    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        vertSpeed = minFall;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (!charController.isGrounded)
        {
            vertSpeed += gravity * 5 * Time.deltaTime;
            if (vertSpeed < terminalVelocity)
            {
                vertSpeed = terminalVelocity;
            }
        }

        movement.y = vertSpeed;
        movement *= Time.deltaTime;
        charController.Move(movement);
    }
}