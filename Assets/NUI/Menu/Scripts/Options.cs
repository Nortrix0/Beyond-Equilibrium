using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using System.Collections;

public class Options : MonoBehaviour {
    GameSettings GameSettings;
    public GameObject OptionsMenu;
	public Toggle InvertX;
    public Toggle InvertY;
    public Toggle SubtitlesButton;
    public Toggle GoreButton;
    public Toggle KeepBodiesButton;
    public Toggle HoldADS;
	bool AcceptedWarning = false;
    public Slider MusicVolSlider;
    public Text MusicVol;
    public Slider DialogueVolSlider;
    public Text DialogueVol;
    public Slider SFXVolSlider;
    public Text SFXVol;
    public AudioMixer MasterMixer;
	
	public GameObject WarningPanel;
    public Button WarningYesButton;
    public Button WarningNoButton;
    public Button DefaultOptions;
	public Button OptionsButton;
    public Button CloseOptions;

	void Start () {
        GameSettings = Settings.GS;
		
		OptionsMenu.SetActive(false);
		WarningPanel.SetActive(false);
		DefaultOptions.onClick.AddListener(OptionsDefault);
		WarningYesButton.onClick.AddListener(WarningYes);
		WarningNoButton.onClick.AddListener(WarningNo);
		OptionsButton.onClick.AddListener(Show);
		CloseOptions.onClick.AddListener(Show);
	}

	void Update () {
        if (MusicVol.text != MusicVolSlider.value.ToString() + " DB" && OptionsMenu.activeInHierarchy)
        {
			MusicVol.text = MusicVolSlider.value.ToString() + " DB";
            MasterMixer.SetFloat("MusicVolume", MusicVolSlider.value);
		}
        if (DialogueVol.text != DialogueVolSlider.value.ToString() + " DB" && OptionsMenu.activeInHierarchy)
        {
            DialogueVol.text = DialogueVolSlider.value.ToString() + " DB";
            MasterMixer.SetFloat("DialougeVolume", DialogueVolSlider.value);
		}
        if (SFXVol.text != SFXVolSlider.value.ToString() + " DB" && OptionsMenu.activeInHierarchy)
        {
            SFXVol.text = SFXVolSlider.value.ToString() + " DB";
            MasterMixer.SetFloat("SFXVolume", SFXVolSlider.value);
		}
	}
	void OptionsDefault(){
		MusicVolSlider.value = 0;
		DialogueVolSlider.value = 0;
		SFXVolSlider.value = 0;
		InvertX.isOn = false;
		InvertY.isOn = false;
		SubtitlesButton.isOn = false;
		GoreButton.isOn = false;
		KeepBodiesButton.isOn = false;
		HoldADS.isOn = true;
		AcceptedWarning = false;
	}
	void KeepBodies(){
		if(!AcceptedWarning){
			WarningPanel.SetActive(true);
		}
	}
	void WarningYes(){
		WarningPanel.SetActive(false);
		KeepBodiesButton.isOn = true;
		AcceptedWarning = true;
	}
	void WarningNo(){
		WarningPanel.SetActive(false);
		KeepBodiesButton.isOn = false;
		AcceptedWarning = false;
	}
	public void Show(){
		OptionsMenu.SetActive(!OptionsMenu.activeSelf);
		if(OptionsMenu.activeSelf){
			InvertX.isOn = GameSettings.InvertX;
            InvertY.isOn = GameSettings.InvertY;
            DialogueVolSlider.value = GameSettings.DialougeVol;
            MusicVolSlider.value = GameSettings.MusicVol;
            SFXVolSlider.value = GameSettings.SFXVol;
            SubtitlesButton.isOn = GameSettings.Subtitles;
            GoreButton.isOn = GameSettings.Gore;
            KeepBodiesButton.isOn = GameSettings.KeepBodies;
            HoldADS.isOn = GameSettings.HoldADS;
		}
		else{
            GameSettings.InvertX = InvertX.isOn;
            GameSettings.InvertY = InvertY.isOn;
            GameSettings.DialougeVol = DialogueVolSlider.value;
            GameSettings.MusicVol = MusicVolSlider.value;
            GameSettings.SFXVol = SFXVolSlider.value;
            GameSettings.Subtitles = SubtitlesButton.isOn;
            GameSettings.Gore = GoreButton.isOn;
            GameSettings.KeepBodies = KeepBodiesButton.isOn;
            GameSettings.HoldADS = HoldADS.isOn;
		}
	}
}
