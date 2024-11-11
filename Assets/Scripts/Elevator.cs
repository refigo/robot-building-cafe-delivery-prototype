using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float floorHeight = 100.0f / 6.0f;
    [SerializeField] private int currentFloor = 1;
    [SerializeField] private int targetFloor = 1;


    private Vector3 startPosition;
    private bool isMoving = false;


    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        if (isMoving) {
            Vector3 targetPosition = startPosition + Vector3.up * floorHeight * (targetFloor - 1);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition) {
                currentFloor = targetFloor;
                isMoving = false;
            }
        }
    }

    public void MoveToFloor(int floor) {
        if (floor != currentFloor) {
            targetFloor = floor;
            isMoving = true;
        }
    }

    public int GetCurrentFloor() {
        return currentFloor;
    }

    public bool isArrived() {
        return !isMoving;
    }

}
