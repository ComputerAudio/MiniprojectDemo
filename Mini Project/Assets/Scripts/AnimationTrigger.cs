using UnityEngine;
using System.Collections;

public class AnimationTrigger : MonoBehaviour {
    public string triggerEnterString;
    public string triggerExitString;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GameObject.FindGameObjectWithTag("UI").GetComponent<Animator>(); 
	}
	
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (triggerEnterString != null)
            {
                anim.SetTrigger(triggerEnterString);
            }
        }
    }

    void OnTriggerExit (Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (triggerExitString != null)
            {
                anim.SetTrigger(triggerExitString);
            }
        }
    }
}
