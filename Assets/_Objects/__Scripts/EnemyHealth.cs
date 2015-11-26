using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int InitHealth = 5;
	public int CurrHealth;

	void Start(){
		CurrHealth = InitHealth;
	}

	void Update () {
		if(CurrHealth <= 0){
            Settings.Stats.Killed += 1;
            GetComponent<PathFind>().Kill();
		}
        if(Time.timeScale == 0){
            GetComponent<AudioSource>().Pause();
        }
        if(Time.timeScale == 1 && !GetComponent<AudioSource>().isPlaying){
            GetComponent<AudioSource>().UnPause();
        }
	}
}
