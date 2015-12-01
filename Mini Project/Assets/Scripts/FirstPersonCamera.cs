using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {
    public float mouseXSensitivity = 30;
    public float mouseYSensitivity = 30;

    float lastYInput;
    float lastXInput;


    void Start()
    {

    }

    void Update()
    {
        lastXInput = Input.GetAxisRaw("Mouse X");
        lastYInput = Input.GetAxisRaw("Mouse Y");

        updateCameraDirection();
    }

    void updateCameraDirection()
    {
        float goalX = transform.eulerAngles.x - (lastYInput  * mouseXSensitivity);
        float goalY = transform.eulerAngles.y + (lastXInput * mouseYSensitivity);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(goalX, goalY, 0), Time.deltaTime * 10);

    }
}
