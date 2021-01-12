using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator anim;
    private bool mRunning;
    public GameObject targetPoint;
    
    

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                _agent.destination = hit.point;
            }
        }
            
              if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                mRunning = false;
            }
            else
            {
                mRunning = true;
            }
            anim.SetBool("IsWalking", mRunning);
                                              
    }
}
