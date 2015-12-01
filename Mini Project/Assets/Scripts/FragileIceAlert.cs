using UnityEngine;
using System.Collections;

public class FragileIceAlert : MonoBehaviour {
    public WheelStatus[] leftWheels;
    public WheelStatus[] rightWheels;

    public AudioSource leftASource;
    public AudioSource rightASource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float leftStatus = 0;
        float rightStatus = 0;
        foreach (WheelStatus stat in leftWheels)
        {
            leftStatus = Mathf.Max(leftStatus, stat.fragility);
        }
        foreach (WheelStatus stat in rightWheels)
        {
            rightStatus = Mathf.Max(rightStatus, stat.fragility);
        }
        leftASource.volume = leftStatus;
        rightASource.volume = rightStatus;
	}
}
