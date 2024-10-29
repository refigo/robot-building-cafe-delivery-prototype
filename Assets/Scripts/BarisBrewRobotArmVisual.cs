using UnityEngine;

public class BarisBrewRobotArmVisual : MonoBehaviour
{
    private const string PLACE_CAFE_OBJECT = "PlaceCafeObject";

    
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void TriggerPlaceCafeObject() {
        animator.SetTrigger(PLACE_CAFE_OBJECT);
    }

}
