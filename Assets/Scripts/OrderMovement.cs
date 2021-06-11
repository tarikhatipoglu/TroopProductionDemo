using UnityEngine;
using UnityEngine.AI;

public class OrderMovement : MonoBehaviour
{
    Camera myCamera;
    NavMeshAgent myAgent;
    public LayerMask ground;

    void Start()
    {
        myCamera = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
            }
        }
    }
}
