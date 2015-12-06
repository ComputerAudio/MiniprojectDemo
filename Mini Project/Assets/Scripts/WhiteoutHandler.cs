using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WhiteoutHandler : MonoBehaviour {
    public SpriteRenderer leftArrow;
    public SpriteRenderer rightArrow;
    public float speedOfBlinker = 3f;
    public float blinkerOnTime = 2f;
    public Transform playerRefernce;
    public ParticleSystem snowFallEffect;
    float blinkerTimer;
    bool snowStormOn;
    //bool blinkerOn;
	
    void Start()
    {
        playerRefernce = GameObject.FindGameObjectWithTag("Player").transform;
    }

	// Update is called once per frame
	void Update () {
        updateBlinker();
	}

    void updateBlinker()
    {
        blinkerTimer = Mathf.MoveTowards(blinkerTimer, 0, Time.deltaTime);
        if (snowStormOn)
        {
            if (blinkerTimer <= 0)
            {
                blinkerTimer = speedOfBlinker;
            }
            if (blinkerTimer <= blinkerOnTime)
            {
                leftArrow.color = Color.green;
            }
            else
            {
                leftArrow.color = Color.white;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            snowStormOn = true;
            snowFallEffect.Play();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            snowFallEffect.Stop();
        }

    }
}
