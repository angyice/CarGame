using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PoliceController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;
    private GameObject _destination;   
    public float smellSense = 5;
    public GameObject[] _destinations;
    public float changeDestinationDistance = 5f;
    public float detectAngle = 90;     
    private bool _isSeeking;
    private float timeToWaitUntilKill = 4f;

    private void SetNextDestination()
    {
        int index = Random.Range(0, _destinations.Length);
        _destination = _destinations[index];
        _agent.destination = _destination.transform.position;
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        SetNextDestination();
    }

    void  OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Invoke("reLoad", timeToWaitUntilKill);
        }
    }

    void reLoad()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Update()
    {      
        var distanceToTarget = Vector3.Distance(transform.position, _player.transform.position);

        Vector3 groundedTarget = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
        Vector3 _playerDirection = groundedTarget - transform.position;

        float angle = Vector3.Angle(_playerDirection, transform.forward);

        RaycastHit hit;
        bool hasHit = Physics.Raycast(transform.position, _playerDirection, out hit);

        if(hasHit)
        Debug.Log(hit.collider.gameObject);

        if (distanceToTarget < smellSense && angle < (detectAngle / 2) && hasHit && hit.collider.gameObject.CompareTag("Player"))
        {
            
            _agent.destination = _player.transform.position;
            _isSeeking = true;
        }
        else
        {
            if (_isSeeking) SetNextDestination();
            _isSeeking = false;

            var distanceToDestination = Vector3.Distance(
                    transform.position,
                    _destination.transform.position
                );
            if (distanceToDestination < changeDestinationDistance)
            {
                SetNextDestination();
            }
        }
    }   
    
    private void OnDrawGizmosSelected()
    {
        
        if (_isSeeking)
        {
            Handles.color = new Color(1f, 0f, 0f, 0.1f);
            Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        }
        else
        {
            Handles.color = new Color(0f, 1f, 0f, 0.1f);
            Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
        }
        
        Handles.DrawSolidDisc(
            transform.position,
            Vector3.up, smellSense
            );
        
        Gizmos.DrawSphere(transform.position, smellSense);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, detectAngle / 2, smellSense);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -detectAngle / 2, smellSense);

        if (_player == null) return;
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, _player.transform.position);

    }
}
