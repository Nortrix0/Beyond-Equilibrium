using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {
	public string SceneName;
	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")){
            Settings.Checkpoint.Reset();
			Settings.UnlockMouse(true);
			Application.LoadLevel(SceneName);
		}
	}
}
