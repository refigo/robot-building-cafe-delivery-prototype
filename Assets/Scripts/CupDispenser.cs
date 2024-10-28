using UnityEngine;

public class CupDispenser : MonoBehaviour {

    // [SerializeField] private Transform coffeeCupPrefab;
    [SerializeField] private CafeObjectSO cafeObjectSO;
    [SerializeField] private Transform dispenserFrontPoint;

    private CafeObject cafeObject;
    
    public void Interact() {
        Debug.Log("Interact!");
        Transform cafeObjectTransform = Instantiate(cafeObjectSO.prefab, dispenserFrontPoint);
        cafeObjectTransform.localPosition = Vector3.zero;

        Debug.Log(cafeObjectTransform.GetComponent<CafeObject>().GetCafeObjectSO().objectName);
    }
}
