using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReciever : MonoBehaviour
{
    private float verticalVelocity;
    [SerializeField] CharacterController controller;

    public Vector3 Movement => Vector3.up * verticalVelocity;

    private void Update()
    {
        if(verticalVelocity<0 && controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }
}
