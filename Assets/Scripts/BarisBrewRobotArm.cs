using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarisBrewRobotArm : MonoBehaviour, ICafeObjectParent {


    [SerializeField] private CupDispenser cupDispenser;
    [SerializeField] private Transform cafeObjectGrabPoint;
    [SerializeField] private Storagy storagy;


    // public Transform robotArm;
    public float rotationSpeed = 45f;
    private bool isRotating = false;
    private bool cupPicked = false;
    private CafeObject cafeObject;

    
    private void Update() {
        if (!cupPicked && Input.GetKeyDown(KeyCode.R) && !isRotating) {
            StartCoroutine(RotateArmUp());
        }
        if (cupPicked && Input.GetKeyDown(KeyCode.R) && !isRotating) {
            StartCoroutine(RotateArmDown());
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

        if (cupPicked == false) {
            cupDispenser.Interact(this);
            cupPicked = true;
        }
    }

    private IEnumerator RotateArmDown() {
        isRotating = true;
        float rotatedAngle = 0f;

        while (rotatedAngle < 90f) {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.down, rotationStep);
            rotatedAngle += rotationStep;
            yield return null;
        }

        Debug.Log("Rotated 90 degrees");
        isRotating = false;

        if (cupPicked == true) {
            cafeObject.SetCafeObjectParent(storagy);
            cupPicked = false;
        }

    }


    public Transform GetCafeObjectFollowTransform() {
        return cafeObjectGrabPoint;
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
