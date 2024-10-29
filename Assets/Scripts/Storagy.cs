using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Storagy : MonoBehaviour, ICafeObjectParent  {


    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform coffeePickupPoint;
    // [SerializeField] private Transform elevatorPosition;
    // [SerializeField] private Transform officePosition;
    [SerializeField] private Transform cafeObjectHoldPoint;
    

    // private NavMeshAgent agent;
    private CafeObject cafeObject;
    private bool arrivedCoffeePickupPoint = false;


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
        if (arrivedCoffeePickupPoint == false) {
            transform.position = Vector3.Lerp(transform.position, coffeePickupPoint.position, Time.deltaTime);
            if (Vector3.Distance(transform.position, coffeePickupPoint.position) < 0.1f) {
                arrivedCoffeePickupPoint = true;
            }
        }

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

    public Transform GetCafeObjectFollowTransform() {
        return cafeObjectHoldPoint;
    }

    public void SetCafeObject(CafeObject cafeObject) {
        this.cafeObject = cafeObject;
    }

    public CafeObject GetCafeObject() {
        return cafeObject;
    }

    public void ClearCafeObject() {
        cafeObject = null;
    }

    public bool HasCafeObject() {
        return cafeObject != null;
    }
}
