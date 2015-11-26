using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class HUDManager : MonoBehaviour
{
    public static Text InteractText;

    public Slider HealthBar;
    public Slider GasBar;
    public Slider FlashlightBar;

    public Text GunText;
    public Text TazerText;
    public Text SecCardText;
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InteractText = GameObject.Find("InteractText").GetComponent<Text>();
        HealthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        GasBar = GameObject.Find("GasBar").GetComponent<Slider>();
        FlashlightBar = GameObject.Find("FlashlightBar").GetComponent<Slider>();
        GunText = GameObject.Find("GunAmount").GetComponent<Text>();
        TazerText = GameObject.Find("TazerAmount").GetComponent<Text>();
        SecCardText = GameObject.Find("SecCardAmount").GetComponent<Text>();
        InteractText.text = "";
	}

    void Update()
    {
        HealthBar.value = Settings.Stats.HealthAmount;
        GasBar.value = Settings.Stats.GasAmount;
        FlashlightBar.value = Settings.Stats.FlashlightAmount;
        GunText.text = Settings.Stats.GunAmmo.ToString();
        TazerText.text = Settings.Stats.TazerAmmo.ToString();
        SecCardText.text = Settings.Stats.SecCardAmmo.ToString();
	}
}
