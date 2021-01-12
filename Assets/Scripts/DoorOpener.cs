using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator _animator;
    private bool _isDoorOpen = false;
    private bool _inTrigger = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            _inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _inTrigger = false;
        }
    }

    void Update()
    {
        if (_inTrigger)
        {
            if (_isDoorOpen == false && Input.GetKeyDown(KeyCode.F))
            {
                _isDoorOpen = true;
                _animator.SetBool("open", true);
            }
            else if (_isDoorOpen == true && Input.GetKeyDown(KeyCode.F))
            {
                _isDoorOpen = false;
                _animator.SetBool("open", false);
            }
        }
    }
}
