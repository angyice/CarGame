using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        controller.Move((Vector3.forward * speed) * Time.deltaTime );
    }
}
