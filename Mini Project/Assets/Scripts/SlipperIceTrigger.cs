using UnityEngine;
using System.Collections;

public class SlipperIceTrigger : MonoBehaviour {
    public float driftSpeed;
    public SpriteRenderer slipperyIceImage;
    float originalDriftSpeed;

    void OnTriggerEnter(Collider collider)
    {
        DrivingMechanics mechanics = collider.GetComponent<DrivingMechanics>();
        if (mechanics != null)
        {
            originalDriftSpeed = mechanics.turnRate;
            driftSpeed = originalDriftSpeed * 5;
            mechanics.turnRate = driftSpeed;
            slipperyIceImage.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        DrivingMechanics mechanics = collider.GetComponent<DrivingMechanics>();
        print(mechanics);
        if (mechanics != null)
        {
            mechanics.turnRate = originalDriftSpeed;
            slipperyIceImage.color = Color.white;
        }
    }
}
