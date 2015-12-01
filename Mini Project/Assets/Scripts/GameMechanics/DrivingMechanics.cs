using UnityEngine;
using System.Collections;

public class DrivingMechanics : MonoBehaviour {
    public float maxSpeed;
    public float acceleration;
    public float turnRate;

    Rigidbody rigid;
    AudioSource aSource;
    float inputSpeed;
    float inputTurn;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        inputSpeed = Input.GetAxisRaw("Vertical");
        inputTurn = Input.GetAxisRaw("Horizontal");

        updateMovement();
        updateRotation();

        aSource.pitch = 1 + rigid.velocity.magnitude / maxSpeed / 1.5f;
    }

    void updateMovement()
    {
        
        Vector3 goalVel = transform.forward * maxSpeed * inputSpeed;

        rigid.velocity = Vector3.Lerp(rigid.velocity, goalVel, Time.deltaTime * acceleration);
    }

    void updateRotation()
    {
        if (Mathf.Abs(inputSpeed) < .001f)
        {
            return;
        }
        float currentRotation = transform.eulerAngles.y;
        float goalRotation = currentRotation + inputTurn * 90;
        Vector3 newDirection = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(currentRotation, goalRotation, Time.deltaTime * turnRate), transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(newDirection);
    }

}
