using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VideoOptions : MonoBehaviour {

	Resolution[] Res;
	[SerializeField] Button ResDDButton;
	[SerializeField] Button CloseVideoOptions;
	[SerializeField] Button OpenVideoOptions;
	[SerializeField] GameObject VideoOptionsPanel;
	[SerializeField] GameObject Templet;
	[SerializeField] Transform Panel;
	[SerializeField] InputField PixelLight;
	[SerializeField] InputField ShadowDis;
	[SerializeField] Toggle FullScreen;
	void Start () {
		Res = Screen.resolutions;
		ResDDButton.onClick.AddListener(DD);
//		int i = 0;
        if(!Application.isEditor){
		    foreach(Resolution res in Res){
			    GameObject go = (GameObject)Instantiate(Templet);
			    go.transform.SetParent(Panel);
			    go.GetComponentInChildren<Text>().text = res.ToString();
                //go.GetComponent<Button>().onClick.AddListener(
                //    () => {SetResolution(i);}
                //    );
		    }
        }
		PixelLight.text =  QualitySettings.pixelLightCount.ToString();
		ShadowDis.text = QualitySettings.shadowDistance.ToString();
		CloseVideoOptions.onClick.AddListener(ShowOptions);
		OpenVideoOptions.onClick.AddListener(ShowOptions);
		Panel.gameObject.SetActive(false);
		VideoOptionsPanel.SetActive(false);
	}
	void Update(){
		QualitySettings.pixelLightCount = int.Parse(PixelLight.text);
		QualitySettings.shadowDistance = float.Parse(ShadowDis.text);
        if(!Application.isEditor){
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreen.isOn);
        }
	}
	void ShowOptions(){
		VideoOptionsPanel.SetActive(!VideoOptionsPanel.activeInHierarchy);
	}
	void DD(){
		Panel.gameObject.SetActive(!Panel.gameObject.activeInHierarchy);
	}
    //void SetResolution(int i){
    //    Screen.SetResolution(Res[i].width, Res[i].height, FullScreen.isOn);
    //}
    void ReloadResolution(){
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreen.isOn);
    }
}
