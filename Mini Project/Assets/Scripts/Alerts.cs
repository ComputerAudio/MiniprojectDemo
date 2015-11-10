using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//attach this Component/Script to a new GameObject in the Hierarchy when finished
[RequireComponent(typeof(AudioSource))] //optional: this automatically adds an AudioSource to your GameObject if it dosen't have one
public class Alerts : MonoBehaviour {

	public AudioSource[] myAudioSources;
	public AudioSource myAudioSource_highSnowLevel;
	public AudioSource myAudioSource_highDrowsiness;

	public AudioClip myAudioClip_highSnowLevel;
	public AudioClip myAudioClip_highDrowsiness;

	// Use this for initialization
	void Start () {
		myAudioSources = GetComponents<AudioSource> (); //grabbing a reference to our AudioSources
		myAudioSource_highSnowLevel = myAudioSources [0];
		myAudioSource_highDrowsiness = myAudioSources [1];

		myAudioSource_highSnowLevel.clip = myAudioClip_highSnowLevel;
		myAudioSource_highDrowsiness.clip = myAudioClip_highDrowsiness;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void highSnowLevelPressed() {
		if (!myAudioSource_highSnowLevel.isPlaying) { 
			myAudioSource_highSnowLevel.Play ();
		} else {
			myAudioSource_highSnowLevel.Stop ();
		}
	} 

	public void highDrowsinessPressed() {
		if (!myAudioSource_highDrowsiness.isPlaying) { 
			myAudioSource_highDrowsiness.Play ();
		} else {
			myAudioSource_highDrowsiness.Stop ();
		}
	} 

	public void setHighSnowLevelPitch(float myValue) {
		myAudioSource_highSnowLevel.pitch = myValue;
	}

	public void setDrowsinessLevelPitch(float myValue) {
		myAudioSource_highDrowsiness.pitch = myValue;
	}
}
