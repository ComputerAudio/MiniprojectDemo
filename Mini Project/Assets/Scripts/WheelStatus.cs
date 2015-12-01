using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WheelStatus : MonoBehaviour {
	public float fragility;
    public WheelInformation information;

	SpriteRenderer myWheel;

	// Use this for initialization
	void Start () {
		myWheel = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
        fragility = information.fragileIce;
		myWheel.color = new Vector4 (fragility, (1 - fragility), 0, 1);
	}

}
