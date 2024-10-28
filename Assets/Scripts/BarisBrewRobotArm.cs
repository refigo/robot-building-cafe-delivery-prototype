using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarisBrewRobotArm : MonoBehaviour {

    // public Transform robotArm;

    public float rotationSpeed = 45f;

    private bool isRotating = false;
    private bool cupPicked = false;

    [SerializeField] private CupDispenser cupDispenser;
    
    private void Update() {
        if (!cupPicked && Input.GetKeyDown(KeyCode.R) && !isRotating) {
            StartCoroutine(RotateArmUp());
        }
    }

    private IEnumerator RotateArmUp() {
        isRotating = true;
        float rotatedAngle = 0f;

        while (rotatedAngle < 90f) {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationStep);
            rotatedAngle += rotationStep;
            yield return null;
        }

        Debug.Log("Rotated 90 degrees");
        isRotating = false;

        cupDispenser.Interact();
        
        // PickUpCup();

    }

    private void PickUpCup() {
        Debug.Log("Picking up cup");
        cupPicked = true;
        // cup.transform.SetParent(robotArm)
    }
}
