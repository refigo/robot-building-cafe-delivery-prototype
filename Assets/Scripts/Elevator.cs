using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    
    
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float floorHeight = 10.0f;
    [SerializeField] private int topFloor = 7;
    [SerializeField] private int bottomFloor = 1;
    
    
    private int targetFloor;
    private Vector3 startPosition;


    void Start() {
        startPosition = transform.position;
        targetFloor = topFloor;
    }

    void Update() {
        Vector3 targetPosition = startPosition + Vector3.up * floorHeight * (targetFloor - 1);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition) {
            if (targetFloor == topFloor) {
                targetFloor = bottomFloor;
            } else if (targetFloor == bottomFloor) {
                targetFloor = topFloor;
            }
        }
    }
}
