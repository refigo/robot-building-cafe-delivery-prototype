using UnityEngine;

public class CupDispenser : MonoBehaviour, ICafeObjectParent {

    // [SerializeField] private Transform coffeeCupPrefab;
    [SerializeField] private CafeObjectSO cafeObjectSO;
    [SerializeField] private Transform dispenserFrontPoint;


    private CafeObject cafeObject;


    public void Interact() {
        if (cafeObject == null) {
            Transform cafeObjectTransform = Instantiate(cafeObjectSO.prefab, dispenserFrontPoint);
            cafeObjectTransform.GetComponent<CafeObject>().SetCafeObjectParent(this);
        } else {
            Debug.Log(cafeObject.GetCafeObjectParent());
        }
    }

    public Transform GetCafeObjectFollowTransform() {
        return dispenserFrontPoint;
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
