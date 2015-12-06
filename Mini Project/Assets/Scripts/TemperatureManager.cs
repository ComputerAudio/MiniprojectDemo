using UnityEngine;
using System.Collections;

public class TemperatureManager : MonoBehaviour {
    public float currentTemperature = -32;
    public SpriteRenderer freezingImage;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        updateTemperatureImage();
    }

    void updateTemperatureImage()
    {
        if (currentTemperature < -45)
        {
            freezingImage.color = Color.red;
        }
        else
        {
            freezingImage.color = Color.white;
        }
    }
}
