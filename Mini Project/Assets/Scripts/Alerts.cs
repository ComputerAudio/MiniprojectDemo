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

	public float lastPlayedTime_highSnowLevel;
	public float lastPlayedTime_highDrowsiness;

	public bool isHighSnowLevelPlaying;
	public bool isHighDrowsinessPlaying;
	// Use this for initialization
	void Start () {
		myAudioSources = GetComponents<AudioSource> (); //grabbing a reference to our AudioSources
		myAudioSource_highSnowLevel = myAudioSources [0];
		myAudioSource_highDrowsiness = myAudioSources [1];

		myAudioSource_highSnowLevel.clip = myAudioClip_highSnowLevel;
		myAudioSource_highDrowsiness.clip = myAudioClip_highDrowsiness;

		lastPlayedTime_highSnowLevel = 0;
		lastPlayedTime_highDrowsiness = 0;

		isHighSnowLevelPlaying = false;
		isHighDrowsinessPlaying = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (isHighSnowLevelPlaying && (Time.timeSinceLevelLoad - lastPlayedTime_highSnowLevel) > 1.5) {
			myAudioSource_highSnowLevel.Play ();
			lastPlayedTime_highSnowLevel = Time.timeSinceLevelLoad;
		}

		if (isHighDrowsinessPlaying && (Time.timeSinceLevelLoad - lastPlayedTime_highDrowsiness) > 0.75) {
			myAudioSource_highDrowsiness.Play ();
			lastPlayedTime_highDrowsiness = Time.timeSinceLevelLoad;
		}
	}

	public void highSnowLevelPressed() {
		if (!isHighSnowLevelPlaying) {
			isHighSnowLevelPlaying = true;
		} else {
			isHighSnowLevelPlaying = false;
			myAudioSource_highSnowLevel.Stop();
		}
	} 

	public void highDrowsinessPressed() {
		if (!isHighDrowsinessPlaying) { 
			isHighDrowsinessPlaying = true;
		} else {
			isHighDrowsinessPlaying = false;
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
