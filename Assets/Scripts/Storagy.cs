using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Storagy : MonoBehaviour
{


    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform coffeePickupPoint;
    // [SerializeField] private Transform elevatorPosition;
    // [SerializeField] private Transform officePosition;
    

    // private NavMeshAgent agent;


    void Start() {
        // agent = GetComponent<NavMeshAgent>();
        // MoveTo(coffeePickupPoint.position);
    }

    // void MoveTo(Vector3 destination) {
    //     agent.SetDestination(destination);
    // }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, coffeePickupPoint.position, Time.deltaTime);
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        
    }
}
