using UnityEngine;
using System.Collections;

public class TemperatureTrigger : MonoBehaviour {
    public TemperatureManager tempManager;
    public float triggerTemperature;

    void OnTriggerEnter(Collider collider)
    {
        tempManager.currentTemperature = triggerTemperature;
    }

    void OnTriggerExit(Collider collider)
    {

    }
}
