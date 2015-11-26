using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsControlButtons : MonoBehaviour {
    OptionsControls OptionsControls;
	ControlSettings ControlSettings;
	Event e;
	void Start () {
        OptionsControls = GameObject.Find("UIManager").GetComponent<OptionsControls>();
        ControlSettings = Settings.CS;
		GetComponent<Button>().onClick.AddListener(Button);
	}
	void Button(){
		StartCoroutine(Check());
	}
	IEnumerator Check(){
		OptionsControls.WaitingPanel.SetActive(true);
		while(OptionsControls.WaitingPanel.activeInHierarchy){
			if(e.keyCode != KeyCode.None){
				Debug.Log(e.keyCode);
				ControlSettings.Keys[transform.GetSiblingIndex()].Key = e.keyCode;
				OptionsControls.WaitingPanel.SetActive(false);
				break;
			}
			yield return new WaitForSeconds(0.01f);
		}
	}
	void OnGUI(){
		e = Event.current;
	}

}
