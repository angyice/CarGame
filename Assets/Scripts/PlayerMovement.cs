using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody controller;
    private Vector3 moveVector;
    private Transform _groundChecker;
    private float speed = 2f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private bool _isGrounded = true;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;


    void Start()
    {
        controller = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
    }

    
    void Update()
    {
        moveVector = Vector3.zero;

        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        //X - Left & Right 
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y - Up & Down
        moveVector.y = verticalVelocity;

        //Z - Forward & Backward
        moveVector.z = speed;

    }

    private void FixedUpdate()
    {
        controller.MovePosition(controller.position + moveVector * speed * Time.fixedDeltaTime);
    }
}
