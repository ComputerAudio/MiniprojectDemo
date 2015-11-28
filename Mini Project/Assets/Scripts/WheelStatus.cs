using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WheelStatus : MonoBehaviour {
	public float fragility;

	Image myWheel;

	// Use this for initialization
	void Start () {
		myWheel = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		myWheel.color = new Vector4 (fragility, (1 - fragility), 0, 1);
	}

}
