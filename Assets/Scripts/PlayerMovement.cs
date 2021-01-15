using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody controller;
    private Transform groundChecker;
    private Vector3 moveVector;
    public LayerMask Ground;

    private float timeToWaitUntilReload = 1f;

    private float speed = 2f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    public float GroundDistance = 0.2f;
    private bool isGrounded = true;

    private bool isDead = false;

    void Start()
    {
        controller = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);

        if (isDead)
        {
            Reload();
        }
    }

    
    void Update()
    {

        moveVector = Vector3.zero;

        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        //X - Left & Right 
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y - Up & Down
        moveVector.y = verticalVelocity;

        //Z - Forward & Backward
        moveVector.z = speed;

    }

    private void FixedUpdate()
    {
        if (isDead)
            return;

        controller.MovePosition(controller.position + moveVector * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Death();
            Invoke("Reload", timeToWaitUntilReload);
        }
    }

    private void Death()
    {
        isDead = true;
    }

    private void Reload()
    {
        SceneManager.LoadScene("CarGame");
    }

}
