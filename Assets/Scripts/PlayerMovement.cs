using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 2f;
    private Camera cam;
    private Vector3 posToMove;
    public static Vector3 hitPosition;
    public static UnityEngine.AI.NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        InteractWithMovement();
    }

    private bool InteractWithMovement()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
        Transform selection = hit.transform;
        if (hasHit)
        {
            if (Input.GetMouseButton(0))
            {
                MoveTo(hit.point, 1f);
            }
            return true;
        }
        return false;
    }
    private Ray GetMouseRay()
    {
        return cam.ScreenPointToRay(Input.mousePosition);
    }
    public void MoveTo(Vector3 destination, float speedFraction)
    {
        _navMeshAgent.destination = destination;
        _navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
    }
}