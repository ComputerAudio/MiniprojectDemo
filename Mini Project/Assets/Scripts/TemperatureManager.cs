using UnityEngine;
using System.Collections;

public class TemperatureManager : MonoBehaviour {
    public float currentTemperature = -32;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
}
