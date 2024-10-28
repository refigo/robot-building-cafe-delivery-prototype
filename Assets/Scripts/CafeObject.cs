using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeObject : MonoBehaviour {


    [SerializeField] private CafeObjectSO cafeObjectSO;


    private ICafeObjectParent cafeObjectParent;


    public CafeObjectSO GetCafeObjectSO() {
        return cafeObjectSO;
    }

    public void SetCafeObjectParent(ICafeObjectParent cafeObjectParent) {
        if (this.cafeObjectParent != null) {
            this.cafeObjectParent.ClearCafeObject();
        }

        this.cafeObjectParent = cafeObjectParent;

        if (cafeObjectParent.HasCafeObject()) {
            Debug.LogError("Counter already has a CafeObject!");
        }

        cafeObjectParent.SetCafeObject(this);

        transform.parent = cafeObjectParent.GetCafeObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    
    public ICafeObjectParent GetCafeObjectParent() {
        return cafeObjectParent;
    }
}
