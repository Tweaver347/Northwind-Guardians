using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    [HideInInspector] public Vector3 dir;
    float hzInput, vtInput;
    CharacterController controller;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundLayer;
    Vector3 spherePos;
    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        Gravity();
    }

    void GetMovementInput()
    {
        hzInput = Input.GetAxis("Horizontal");
        vtInput = Input.GetAxis("Vertical");

        dir = transform.forward * vtInput + transform.right * hzInput;

        controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);

    }
}
