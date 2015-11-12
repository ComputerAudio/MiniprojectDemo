using UnityEngine;
using System.Collections;

public class AlignWithTruck : MonoBehaviour {
    public DrivingMechanics driveMechanics;
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float goalRotation = driveMechanics.transform.eulerAngles.y;
        Vector3 newEuler = new Vector3(driveMechanics.transform.eulerAngles.x, Mathf.MoveTowards(transform.eulerAngles.y, goalRotation, Time.deltaTime * rigid.velocity.magnitude),
            driveMechanics.transform.eulerAngles.z);

	}
}
