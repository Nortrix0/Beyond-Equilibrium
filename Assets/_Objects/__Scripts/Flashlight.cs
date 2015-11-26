using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flashlight : MonoBehaviour {
    public GameSettings GameSettings;
	public Light FlashlightLight;
	public bool on;
	public float BatteryLife;

    void Start()
    {
        GameSettings = Settings.GS;
		FlashlightLight = GameObject.Find("Flashlight-Light").GetComponent<Light>();
		FlashlightLight.enabled = false;
		on = false;
        if (GameSettings.Difficulty == 0) BatteryLife = .005f;
        if (GameSettings.Difficulty == 1) BatteryLife = .001f;
        if (GameSettings.Difficulty == 2) BatteryLife = .05f;
        if (GameSettings.Difficulty == 3) BatteryLife = .01f;
	}

	void Update () {
        FlashlightLight.intensity = Settings.Stats.FlashlightAmount * 5;
		if(Input.GetKeyDown(Settings.CS.Keys[1].Key) && Time.timeScale == 1f){
			on = !on;
		}
        if (on && Settings.Stats.FlashlightAmount > 0)
        {
			FlashlightLight.enabled = true;
            Settings.Stats.FlashlightAmount -= (BatteryLife * Time.deltaTime);
		}
		else{
			FlashlightLight.enabled = false;
			on = false;
		}
	}
}
