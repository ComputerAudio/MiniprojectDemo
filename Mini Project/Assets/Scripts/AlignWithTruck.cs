using UnityEngine;
using System.Collections;

public class AlignWithTruck : MonoBehaviour {
    public DrivingMechanics driveMechanics;
    //public float turnRate = 5;
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = driveMechanics.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float speed = rigid.velocity.magnitude;
        if (speed > .01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, driveMechanics.transform.rotation, Time.fixedDeltaTime * speed / 45);
        }

	}
}
