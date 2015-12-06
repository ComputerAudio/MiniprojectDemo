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
    public AudioSource leftBlinkSound;
    public AudioSource rightBlinkSound;
    AudioSource aSource;
    float blinkerTimer;
    bool snowStormOn;
    //bool blinkerOn;
	
    void Start()
    {
        playerRefernce = GameObject.FindGameObjectWithTag("Player").transform;
        aSource = GetComponent<AudioSource>();
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
            float blinkerDistance = playerRefernce.position.x - transform.position.x;
            

            if (blinkerTimer <= 0)
            {
                blinkerTimer = speedOfBlinker;
            }
            SpriteRenderer arrowToChange;
            AudioSource soundToChange;
            if (blinkerDistance > 0)
            {
                arrowToChange = rightArrow;
                soundToChange = rightBlinkSound;
            }
            else
            {
                arrowToChange = leftArrow;
                soundToChange = leftBlinkSound;
            }
            if (Mathf.Abs(blinkerDistance) < 3)
            {
                leftBlinkSound.Stop();
                rightBlinkSound.Stop();
                leftArrow.color = Color.white;
                rightArrow.color = Color.white;
                return;
            }
            if (blinkerTimer <= blinkerOnTime)
            {
                arrowToChange.color = Color.green;
                if (!soundToChange.isPlaying)
                {
                    soundToChange.Play();

                }


            }
            else
            {
                arrowToChange.color = Color.white;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            snowStormOn = true;
            snowFallEffect.Play();
            aSource.Play();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            snowFallEffect.Stop();
            snowStormOn = false;
            rightArrow.color = Color.white;
            leftArrow.color = Color.white;
            aSource.Stop();
        }

    }
}
