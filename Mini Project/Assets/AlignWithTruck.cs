using UnityEngine;
using System.Collections;

public class AlignWithTruck : MonoBehaviour {
    public DrivingMechanics driveMechanics;
    public float turnRate = 5;
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = driveMechanics.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float goalRotation = driveMechanics.transform.eulerAngles.y;
        Vector3 newEuler = new Vector3(driveMechanics.transform.eulerAngles.x, Mathf.MoveTowards(transform.eulerAngles.y, goalRotation, Time.deltaTime * rigid.velocity.magnitude * turnRate),
            driveMechanics.transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(newEuler);

	}
}
