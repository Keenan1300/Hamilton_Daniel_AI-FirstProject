
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public LayerMask groundLayerMask;
    private NavMeshAgent navAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        bool leftMouseClicked = Mouse.current.leftButton.wasPressedThisFrame;

        if(leftMouseClicked)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            //Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Ray mouseClickRay = Camera.main.ScreenPointToRay(mousePosition);

            //Contain details on whatever it is that we hit with our raycast
            RaycastHit mouseClickHit;

            if(Physics.Raycast(mouseClickRay, out mouseClickHit, 25f, groundLayerMask))
            {
                //Player moves to the position of the point that the raycast hit
                navAgent.SetDestination(mouseClickHit.point);


            }

        }
    }
}

