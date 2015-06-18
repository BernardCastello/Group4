using UnityEngine;
using System.Collections;

public class FixExit : MonoBehaviour {

	// Use this for initialization

    public AudioClip GameOver;

	void Start () {
        HUDManager.instance.SetState("start",  false);
        HUDManager.instance.SetState("panel",  false);
        HUDManager.instance.SetState("menu",   false);
        HUDManager.instance.SetState("finish", true);
        AudioManager.instance.PlayAudio(GameOver);

        print("fix exit");
	
	}
	
}
