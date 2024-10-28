using UnityEngine;

public class CupDispenser : MonoBehaviour {

    [SerializeField] private Transform coffeeCupPrefab;
    [SerializeField] private Transform dispenserFrontPoint;

    private CafeObject cafeObject;
    
    public void Interact() {
        Debug.Log("Interact!");
        Transform coffeeCupTransform = Instantiate(coffeeCupPrefab, dispenserFrontPoint);
        coffeeCupTransform.localPosition = Vector3.zero;
    }
}
