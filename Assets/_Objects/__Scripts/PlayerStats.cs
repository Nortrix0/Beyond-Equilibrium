using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public static GameObject Player;
    Vector3 Cam;
    float CamPos_Main;
    float CamPos_Regular;
    float CamPos_Sneak;
    bool _isSneaking;
    public bool isSneaking{
     get{
         return _isSneaking;
     }   
    }
    void Awake()
    {
        Player = this.gameObject;
    }
    void Start()
    {
        if (Settings.GS.Difficulty == 0)
        {
            Settings.Stats.HealthAmount = 2;
            Settings.Stats.MaxHealth = 2;
        }
        if (Settings.GS.Difficulty == 1)
        {
            Settings.Stats.HealthAmount = 1;
            Settings.Stats.MaxHealth = 1;
        }
        if (Settings.GS.Difficulty == 2)
        {
            Settings.Stats.HealthAmount = .5f;
            Settings.Stats.MaxHealth = .5f;
        }
        if (Settings.GS.Difficulty == 3)
        {
            Settings.Stats.HealthAmount = .25f;
            Settings.Stats.MaxHealth = .25f;
        }
        if (Settings.Stats.Checkpoint)
        {
            Player.transform.position = Settings.Stats.Position;
            Player.transform.rotation = Settings.Stats.Rotation;
        }
    }
    void Update()
    {
        Cam = Camera.main.transform.position;
        CamPos_Main = Camera.main.transform.position.y;
        CamPos_Regular = CamPos_Main;
        CamPos_Sneak = .4f;
        if (Settings.Stats.HealthAmount <= 0)
        {
			GameOver();
		}
        if (Settings.Stats.GasAmount <= .5f)
        {
            Settings.Stats.HealthAmount -= .001f;
		}
        if (Settings.Stats.GasAmount <= 0f)
        {
            Settings.Stats.HealthAmount -= 1f;
		}
		if(Input.GetKeyDown(KeyCode.Return)){
			Time.timeScale = 1;
			StopAllCoroutines();
			Application.LoadLevel(Application.loadedLevel);
		}
		if(Input.GetKey(Settings.CS.Keys[2].Key)){
            if(_isSneaking){
                CamPos_Main += CamPos_Sneak;
            }
            _isSneaking = true;
			CamPos_Main -= CamPos_Sneak;
			GetComponent<AudioSource>().volume = .1f;
		}
		else{
            if(_isSneaking){
                CamPos_Regular += CamPos_Sneak;
            }
            _isSneaking = false;
			CamPos_Main = CamPos_Regular;
			GetComponent<AudioSource>().volume = .6f;
		}
        Cam.y = CamPos_Main;
        Camera.main.transform.position = Cam;
        if(!Settings.Checkpoint.Checkpoint){
            Settings.Stats.Time = Time.timeSinceLevelLoad + Settings.Checkpoint.Time;
        }
        else
        {
            Settings.Stats.Time = Time.timeSinceLevelLoad;
        }
	}

	void GameOver(){
		Time.timeScale = 0f;
        if(!Settings.Checkpoint.Checkpoint){
            HUDManager.InteractText.text = "GAME OVER, PRESS ENTER RESPAWN";
        }
        else
        {
            HUDManager.InteractText.text = "GAME OVER, PRESS BACKSPACE TO REVERT TO LAST CHECKPOINT";
        }
	}
}
