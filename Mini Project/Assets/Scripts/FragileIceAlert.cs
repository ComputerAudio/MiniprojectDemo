using UnityEngine;
using System.Collections;

public class FragileIceAlert : MonoBehaviour {
    public AudioClip[] clips;
    public WheelInformation[] leftWheels;
    public WheelInformation[] rightWheels;

    public AudioSource leftASource;
    public AudioSource rightASource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float leftStatus = 0;
        float rightStatus = 0;
        foreach (WheelInformation stat in leftWheels)
        {
            leftStatus = Mathf.Max(leftStatus, stat.fragileIce);
        }
        foreach (WheelInformation stat in rightWheels)
        {
            

            rightStatus = Mathf.Max(rightStatus, stat.fragileIce);
        }
        if (leftStatus > .001f)
        {
            if (!leftASource.isPlaying)
            {
                leftASource.Play();
            }
            
        }
        if (rightStatus > .001f)
        {
            if (!rightASource.isPlaying)
            {
                rightASource.Play();
            }
        }
        
        setAppropriateClip(leftASource, leftStatus);
        setAppropriateClip(rightASource, rightStatus);

        leftASource.volume = leftStatus;
        rightASource.volume = rightStatus;
	}

    void setAppropriateClip(AudioSource audio, float value)
    {
        if (value < 0.25f)
        {
            audio.clip = clips[0];
        }
        else if (value < .6f)
        {
            audio.clip = clips[1];
        }
        else
        {
            audio.clip = clips[2];
        }
    }
}
