using UnityEngine;
using System.Collections;

public class ThermometerScale : MonoBehaviour {
    public TemperatureManager manager;
    float scaleY;

    void Update()
    {
        float currentTemp = manager.currentTemperature;
        currentTemp = currentTemp + 70;
        currentTemp = currentTemp / 40f * .5f;
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x, currentTemp, scale.z);

    }

}
