using UnityEngine;
using System.Collections;

public class TemperatureTrigger : MonoBehaviour {
    public AudioClip clip;
    public AudioSource aSource;
    public TemperatureManager tempManager;
    public float triggerTemperature;

    void OnTriggerEnter(Collider collider)
    {
        tempManager.currentTemperature = triggerTemperature;
        DrivingMechanics dMechanics = collider.GetComponent<DrivingMechanics>();
        if (dMechanics != null)
        {
            aSource.Stop();
            aSource.clip = clip;
            aSource.Play();
        }
        

    }

    void OnTriggerExit(Collider collider)
    {

    }
}
