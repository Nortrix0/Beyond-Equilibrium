using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class OptionsControls : MonoBehaviour {
    ControlSettings ControlSettings;
	public GameObject Templet;
	GameObject ControlsPanel;
	public GameObject WaitingPanel;
	Button ControlPanelButton;
	Button ControlsDefaultButton;
	Button ControlsCloseButton;

	void Start () {
        ControlSettings = Settings.CS;
		ControlsPanel = GameObject.Find("ControlsPanel");
		WaitingPanel = GameObject.Find("WaitingPanel");
		ControlPanelButton = GameObject.Find("ControlsButton").GetComponent<Button>();
		ControlsDefaultButton = GameObject.Find("ControlsDefaultButton").GetComponent<Button>();
		ControlsCloseButton = GameObject.Find("ControlsCloseButton").GetComponent<Button>();
		GameObject go;
		foreach(Controls Control in Settings.CS.Keys){
			go = (GameObject)Instantiate(Templet);
			go.transform.SetParent(ControlsPanel.transform.GetChild(0));
			go.name = Control.Name;
            if (Control.Key != 0)
            {
                Control.Key = Control.Default;
            }
            go.transform.GetChild(0).GetComponent<Text>().text = Control.Name + ": " + Control.Key;
		}
		ControlPanelButton.onClick.AddListener(ShowPanel);
		ControlsDefaultButton.onClick.AddListener(Default);
		ControlsCloseButton.onClick.AddListener(ShowPanel);
		ControlsPanel.SetActive(false);
		WaitingPanel.SetActive(false);
	}
	void ShowPanel(){
		ControlsPanel.SetActive(!ControlsPanel.activeInHierarchy);
	}
	void Default(){
        for (int i = 0; i < ControlSettings.Keys.Count; i++)
        {
            ControlSettings.Keys[i].Key = ControlSettings.Keys[i].Default;
		}
	}
	void Update(){
        for (int i = 0; i < ControlSettings.Keys.Count; i++)
        {
            ControlsPanel.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Text>().text = ControlSettings.Keys[i].Name + ": " + ControlSettings.Keys[i].Key;
		}
	}
}
