using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour {
    Animator Anim;
    GameSettings GameSettings;
	public RaycastHit hitinfo;
	public AudioSource ASource;
	public AudioClip[] AClip;
	public bool shootGun = true;
    public bool Silenced = false;
	public int DifficutlyAmount;
	public bool HoldADS;
	public bool ADS;
	public float ADSLerpTime;
    public GameObject HitParticle;
    public GameObject Shell;
    public Vector3 offset;
    public Vector3 Force;
	Camera MainCam;

    void Start()
    {
        Anim = GetComponent<Animator>();
        GameSettings = Settings.GS;
		ASource = GetComponent<AudioSource>();
		MainCam = Camera.main;
		ASource.volume = ASource.volume * (GameSettings.SFXVol/100);
        if (GameSettings.Difficulty == 0) DifficutlyAmount = 4;
        if (GameSettings.Difficulty == 1) DifficutlyAmount = 3;
        if (GameSettings.Difficulty == 2) DifficutlyAmount = 2;
        if (GameSettings.Difficulty == 3) DifficutlyAmount = 1;

	}

	void Update () {
        if(Silenced){
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
		HoldADS = GameSettings.HoldADS;
		int clip;
		if(ADS){
			Aim();
		}
		else{
			UnAim();
		}
		if(Input.GetMouseButtonUp(1) && HoldADS){
			UnAim();
		}
		else if(Input.GetMouseButtonDown(1) && ADS){
			UnAim();
		}
		else if(Input.GetMouseButtonDown(1) && HoldADS){
			Aim();
		}
		else if(Input.GetMouseButtonDown(1) && !HoldADS){
			Aim ();
		}
        if (Input.GetKeyDown(Settings.CS.Keys[7].Key))
        {
            Silenced = !Silenced;
        }
        if (Physics.Raycast(MainCam.transform.position, MainCam.transform.forward, out hitinfo, 100f) && Time.timeScale == 1f)
        {
			if(Input.GetMouseButtonDown(0) && shootGun){
                if (Settings.Stats.GunAmmo > 0)
                {
					clip = 0;
					if(hitinfo.collider.GetComponent<EnemyHealth>()){
						hitinfo.collider.GetComponent<PathFind>().TargetPlayer();
						hitinfo.collider.GetComponent<EnemyHealth>().CurrHealth -= DifficutlyAmount;
					}
                    if(hitinfo.collider.GetComponent<SteamAmount>()){
                        GameObject go = (GameObject)Instantiate(HitParticle, hitinfo.point, Quaternion.identity);
                        go.GetComponent<SteamHole>().HitObject = hitinfo.collider.gameObject;
                    }
                    GameObject shell = (GameObject)Instantiate(Shell, transform.position + offset, Quaternion.AngleAxis(-90, Vector3.forward));
                    Vector3 NewForce = Vector3.forward + Force;
                    shell.AddComponent<Rigidbody>().AddRelativeForce(NewForce, ForceMode.Impulse);
                    shell.AddComponent<BoxCollider>();
                    Settings.Stats.GunAmmo -= 1;
                    Settings.Stats.GunAmmoUsed += 1;
				}
				else{
					clip = 1;
				}
				PlayClip(AClip[clip]);
			}
		}
		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo, 10f) && Time.timeScale == 1f){
            if (Input.GetMouseButtonDown(0) && Settings.Stats.TazerAmmo > 0 && !shootGun)
            {
				if(hitinfo.collider.GetComponent<PathFind>()){
					StartCoroutine(hitinfo.collider.GetComponent<PathFind>().Stop());
				}
                Settings.Stats.TazerAmmo -= 1;
                Settings.Stats.TaserAmmoUsed += 1;
				PlayClip(AClip[2]);
			}
            if (Input.GetKeyDown(Settings.CS.Keys[4].Key) && Settings.Stats.SecCardAmmo > 0)
            {
				if(hitinfo.collider.GetComponent<SecurityCam>() && !hitinfo.collider.GetComponent<SecurityCam>().IsFriendly){
					hitinfo.collider.GetComponent<SecurityCam>().IsFriendly = true;
                    Settings.Stats.SecCardAmmo -= 1;
                    Settings.Stats.SecCardAmmoUsed += 1;
				}
				if(hitinfo.collider.GetComponent<HackDoor>() && hitinfo.collider.GetComponent<HackDoor>().isOpen){
					hitinfo.collider.GetComponent<HackDoor>().Close();
				}
				if(hitinfo.collider.GetComponent<HackDoor>() && !hitinfo.collider.GetComponent<HackDoor>().isOpen){
					hitinfo.collider.GetComponent<HackDoor>().Open();
				}
			}
		}
		if(Input.GetKeyDown(Settings.CS.Keys[3].Key)){
			SwapMode();
		}
	}
	void SwapMode(){
        GameObject.Find("HUD").GetComponent<Canvas>().transform.GetChild(3).SetSiblingIndex(4);
		shootGun = !shootGun;
	}
	void PlayClip(AudioClip clip){
        if(Silenced){
            ASource.volume = .4f;
        }
        else
        {
            ASource.volume = .6f;
        }
        Anim.SetTrigger("Fire");
		ASource.clip = clip;
		ASource.Play();
	}
	void Aim(){
		ADS = true;
		MainCam.fieldOfView = Mathf.MoveTowards(MainCam.fieldOfView, 40f, ADSLerpTime * Time.deltaTime);
	}
	void UnAim(){
		ADS = false;
		MainCam.fieldOfView = Mathf.MoveTowards(MainCam.fieldOfView, 60f, ADSLerpTime * Time.deltaTime);
	}
}
