using UnityEngine;
using System.Collections;

public class SlipperIceTrigger : MonoBehaviour {
    public float driftSpeed;
    float originalDriftSpeed;

    void OnTriggerEnter(Collider collider)
    {
        DrivingMechanics mechanics = collider.GetComponent<DrivingMechanics>();
        if (mechanics != null)
        {
            originalDriftSpeed = mechanics.turnRate;
            driftSpeed = originalDriftSpeed * 5;
            mechanics.turnRate = driftSpeed;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        DrivingMechanics mechanics = GetComponent<DrivingMechanics>();
        if (mechanics != null)
        {
            mechanics.turnRate = originalDriftSpeed;
        }
    }
}
