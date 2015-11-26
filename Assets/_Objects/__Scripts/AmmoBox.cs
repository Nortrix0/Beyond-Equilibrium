using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class AmmoBox : MonoBehaviour {
    GameSettings GameSettings;
	public string AmmoType;

    void Start()
    {
        GameSettings = Settings.GS;
        if (GameSettings.Difficulty == 3)
        {
			gameObject.SetActive(false);
		}
        else
        {
            GameObject.Find("Pickups").GetComponent<AmmoTypes>().RandomAmmo(this.gameObject);
        }
	}

	void OnTriggerStay(){
		if(gameObject.activeInHierarchy){
            HUDManager.InteractText.text = "Press " + Settings.CS.Keys[0].Key.ToString() + " To Pick Up " + AmmoType;
            if (Input.GetKey(Settings.CS.Keys[0].Key) && Time.timeScale == 1f)
            {
				AmmoTypes.GetAmmo(AmmoType, this.gameObject);
			}
		}
	}
	void OnTriggerExit(){
        HUDManager.InteractText.text = "";
	}
	
//	void OnDestroy(){
//		Toolbox.Instance.InteractText.text = "";
//	}
}
