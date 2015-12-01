using UnityEngine;
using System.Collections;

public class SleepUseCase : MonoBehaviour {
    public string triggerEnterString;
    public AudioSource alarmSound;
    public string triggerExitString;
    public float delayAlarm = 1.2f;
    float alarmTimer;
    Animator anim;
    bool passThroughSleepTrigger;

	// Use this for initialization
	void Start () {
        anim = GameObject.FindGameObjectWithTag("UI").GetComponent<Animator>();
        alarmTimer = delayAlarm;
	}
	
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (triggerEnterString != null)
            {
                anim.SetTrigger(triggerEnterString);
                passThroughSleepTrigger = true;

            }
        }
    }

    void Update()
    {
        if (passThroughSleepTrigger)
        {
            alarmTimer = Mathf.MoveTowards(alarmTimer, 0, Time.deltaTime);
        }

        if (alarmTimer <= 0)
        {
            if (!alarmSound.isPlaying)
            {
                alarmSound.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)&& passThroughSleepTrigger)
        {
            passThroughSleepTrigger = false;
            alarmSound.Stop();
            alarmTimer = delayAlarm;
            anim.SetTrigger("WakeUp");
        }
    }
}
