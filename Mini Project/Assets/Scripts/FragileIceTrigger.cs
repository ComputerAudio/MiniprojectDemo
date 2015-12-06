using UnityEngine;
using System;
using System.Collections;

public class FragileIceTrigger : MonoBehaviour {
    public SpriteRenderer fragileIceImage;
    ArrayList wheelInformation = new ArrayList();

    void OnTriggerEnter(Collider collider)
    {
        WheelInformation info = collider.GetComponent<WheelInformation>();
        if (info != null && !wheelInformation.Contains(info))
        {
            wheelInformation.Add(info);
        }

    }

    void OnTriggerExit(Collider collider)
    {
        WheelInformation info = collider.GetComponent<WheelInformation>();
        if (info != null && wheelInformation.Contains(info))
        {
            wheelInformation.Remove(info);
        }
        if (wheelInformation.Count <= 0)
        {
            fragileIceImage.color = Color.white;
        }
    }

    void Update()
    {

        if (wheelInformation.Count > 0)
        {
            fragileIceImage.color = Color.red;
        }
        foreach (WheelInformation stat in wheelInformation)
        {
            float mag = (stat.transform.position - transform.position).magnitude;
            if (mag > transform.localScale.x / 2)
            {
                mag = transform.localScale.x / 2;
            }
            stat.fragileIce = Mathf.Abs(mag / (transform.localScale.x / 2) - 1);
        }
    }
}
