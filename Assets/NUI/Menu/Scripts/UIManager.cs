using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
    GameSettings GameSettings;
	public bool OldSave;
	GameObject OpeningCanvas;
	GameObject MainMenuCanvas;
	GameObject BackGround;
	Button NewGameButton;
	Button LoadGameButton;
	Button LoadLastGameButton;
	Button ExitButton;
	bool IsCutscenePlaying;
	int timer;
	Image DifPanel;
	Button Play;
	GameObject LoadLevelPanel;
	Slider LoadProgress;
	private AsyncOperation levelLoad = null;

    void Start()
    {
        GameSettings = Settings.GS;
		OpeningCanvas = GameObject.Find("OpeningScreen");
		MainMenuCanvas = GameObject.Find("MainMenu");
		BackGround = GameObject.Find("BackGround");
		LoadLevelPanel = GameObject.Find("LevelLoadPanel");
		LoadProgress = GameObject.Find("LoadProgress").GetComponent<Slider>();
		NewGameButton = GameObject.Find("NewGameButton").GetComponent<Button>();
		LoadGameButton = GameObject.Find("LoadGameButton").GetComponent<Button>();
		LoadLastGameButton = GameObject.Find("LoadLastGameButton").GetComponent<Button>();
		ExitButton = GameObject.Find("ExitButton").GetComponent<Button>();
		DifPanel = GameObject.Find("Difficulty").GetComponent<Image>();
		Play = GameObject.Find("PlayButton").GetComponent<Button>();
		if(OldSave){
			LoadGameButton.interactable = true;
			LoadLastGameButton.interactable = true;
		}
		NewGameButton.onClick.AddListener(NewGame);
		LoadGameButton.onClick.AddListener(LoadGame);
		LoadLastGameButton.onClick.AddListener(LoadLastGame);
		ExitButton.onClick.AddListener(ExitGame);
		Play.onClick.AddListener(PlayGame);

		MainMenuCanvas.SetActive(false);
		DifPanel.gameObject.SetActive(false);
		LoadLevelPanel.SetActive(false);

		timer = 0;
		StartCoroutine(CutsceneTimer());
	}

	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			ExitGame();
		}
		if(timer > 120f && !IsCutscenePlaying){
			print("CUTSCENE TIME!");
			IsCutscenePlaying = true;
		}
		if(Input.anyKey && !IsCutscenePlaying){
			BeginGame();
			timer = 0;
			StopCoroutine(CutsceneTimer());
		}
		if(Input.anyKey && IsCutscenePlaying){
			print("CUTSCENE OVER!");
			timer = 0;
			IsCutscenePlaying = false;
		}
		if(LoadLevelPanel.activeInHierarchy && levelLoad != null){
			LoadProgress.value = levelLoad.progress;
		}
	}
	void BeginGame(){
		OpeningCanvas.SetActive(false);
		MainMenuCanvas.SetActive(true);
		BackGround.transform.GetChild(1).gameObject.SetActive(false);
	}
	void ExitGame(){
		Application.Quit();
	}
	void NewGame(){
		DifPanel.gameObject.SetActive(true);
	}
	void PlayGame(){
		for(int i = 0; i < 4; i++){
			if(DifPanel.transform.GetChild(i).GetComponent<Toggle>().isOn){
//				Dif = (Difficutly)i;
                GameSettings.Difficulty = i;
			}
		}
		LoadLevelPanel.SetActive(true);
		StartCoroutine(LoadLevel());
	}
	private IEnumerator LoadLevel(){
        Settings.Stats.FlashlightAmount = 1;
        Settings.Stats.GunAmmo = 9;
        StopAllCoroutines();
		levelLoad = Application.LoadLevelAsync("Level1");
		yield return levelLoad;
		}
	void LoadGame(){
		print("LoadGame");
	}
	void LoadLastGame(){
		print("LoadLastGame");
	}
	IEnumerator CutsceneTimer(){
		timer++;
		yield return new WaitForSeconds(1f);
		//print (timer);
		StartCoroutine(CutsceneTimer());
	}
}
