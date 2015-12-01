using UnityEngine;
using System;
using System.Collections;

public class FragileIceTrigger : MonoBehaviour {
    ArrayList wheelInformation = new ArrayList();

    void OnTriggerEnter(Collider collider)
    {
        WheelInformation info = collider.GetComponent<WheelInformation>();
        if (info != null && !wheelInformation.Contains(info))
        {
            wheelInformation.Add(info);
        }

    }

    void Update()
    {

        
        foreach (WheelInformation stat in wheelInformation)
        {
            float mag = (stat.transform.position - transform.position).magnitude;
            if (mag > 20)
            {
                mag = 20;
            }
            stat.fragileIce = Mathf.Abs(mag / 20 - 1);
        }
    }
}
