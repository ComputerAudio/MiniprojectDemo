using UnityEngine;
using System.Collections;

public class DrivingMechanics : MonoBehaviour {
    public float maxSpeed;
    public float acceleration;

    Rigidbody rigid;
    float inputSpeed;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputSpeed = Input.GetAxisRaw("Vertical");

        updateMovement();
    }

    void updateMovement()
    {
        Vector3 goalVel = transform.forward * maxSpeed * inputSpeed;

        rigid.velocity = Vector3.Lerp(rigid.velocity, goalVel, Time.deltaTime * acceleration);
    }

}
