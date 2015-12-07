using UnityEngine;
using System.Collections;

public class SlipperIceTrigger : MonoBehaviour {
    public float driftSpeed;
    public AudioClip[] clips = new AudioClip[3];
    public SpriteRenderer slipperyIceImage;
    Transform playerPosition;
    float originalDriftSpeed;
    bool playSound;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerPosition != null)
        {
            float zDistance = Mathf.Abs(playerPosition.position.z - transform.position.z);
            if (zDistance < 25)
            {
                aSource.clip = clips[2];
            }
            else if (zDistance < 50)
            {
                aSource.clip = clips[1];
            }
            else
            {
                aSource.clip = clips[0];
            }
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        } else
        {
            aSource.Stop();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        DrivingMechanics mechanics = collider.GetComponent<DrivingMechanics>();
        if (mechanics != null)
        {
            originalDriftSpeed = mechanics.turnRate;
            driftSpeed = originalDriftSpeed * 5;
            mechanics.turnRate = driftSpeed;
            slipperyIceImage.color = Color.red;
            playSound = true;
            playerPosition = collider.transform;

        }
    }

    void OnTriggerExit(Collider collider)
    {
        DrivingMechanics mechanics = collider.GetComponent<DrivingMechanics>();

        if (mechanics != null)
        {
            mechanics.turnRate = originalDriftSpeed;
            slipperyIceImage.color = Color.white;
            playSound = false;
            playerPosition = null;
        }
    }
}
