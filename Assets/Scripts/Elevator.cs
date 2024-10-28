using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator0 : MonoBehaviour {
    // [SerializeField] private float moveSpeed = 3f;
    [SerializeField] Transform firstFloorPosition;
    [SerializeField] Transform sevenFloorPosition;

    public void MoveToSeventhFloor() {
        // Debug.Log("Moving to seventh floor");
        transform.position = Vector3.Lerp(transform.position, sevenFloorPosition.position, Time.deltaTime);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Math.Abs(transform.position - sevenFloorPosition.position) < 0.1f) {
        //     Debug.Log("Arrived at seventh floor");
        //     return;
        // }
        MoveToSeventhFloor();
    }
}
