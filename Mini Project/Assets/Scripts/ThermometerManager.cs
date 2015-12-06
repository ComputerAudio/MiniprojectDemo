using UnityEngine;
using System.Collections;

public class ThermometerManager : MonoBehaviour {
    public TemperatureManager manager;
    TextMesh text;

    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    void Update()
    {
        int temp = (int)manager.currentTemperature;
        text.text = "" + temp;
    }
}
