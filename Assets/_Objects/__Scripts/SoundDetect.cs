using UnityEngine;
using System.Collections;

public class SoundDetect : MonoBehaviour {
    PlayerStats PS;
    public GameSettings GameSettings;
	public AudioSource PlayerAudio;
	public AudioSource GunAudio;
	public bool ifMoving;

    void Start()
    {
        GameSettings = Settings.GS;
        PS = GetComponent<PlayerStats>();
        PlayerAudio = GetComponent<AudioSource>();
		GunAudio = PlayerAudio.transform.GetChild(0).GetChild(0).GetComponent<AudioSource>();
		PlayerAudio.volume = PlayerAudio.volume * (GameSettings.SFXVol/100);
        GunAudio.volume = GunAudio.volume * (GameSettings.SFXVol / 100);

        if (PlayerAudio != null)
        {
            StartCoroutine(CheckPlayerAudio());
            StartCoroutine(CheckSneakAudio());
            StartCoroutine(CheckGunAudio());
            StartCoroutine(CheckSilencedGunAudio());
        }
	}
	
	public IEnumerator CheckPlayerAudio(){
		Collider[] PlayerCols = Physics.OverlapSphere(transform.position, 10f);
		int i = 0;
		ifMoving = GetComponent<CharacterController>().velocity.sqrMagnitude > 0;
		while(i < PlayerCols.Length){
			if(PlayerCols[i].GetComponent<PathFind>()){
                if (ifMoving && !PS.isSneaking)
                {
					PlayerCols[i].GetComponent<PathFind>().TargetPlayer();
				}
			}
			i++;
		}
		yield return new WaitForSeconds(.5f);
		StartCoroutine(CheckPlayerAudio());
	}
	public IEnumerator CheckSneakAudio(){
		Collider[] SneakCols = Physics.OverlapSphere(transform.position, 1f);
		int i = 0;
		while(i < SneakCols.Length){
			if(SneakCols[i].GetComponent<PathFind>()){
				if(ifMoving && PS.isSneaking && !SneakCols[i].GetComponent<PathFind>().Wandering){
					SneakCols[i].GetComponent<PathFind>().TargetPlayer();
				}
			}
			i++;
		}
		yield return new WaitForSeconds(.5f);
		StartCoroutine(CheckSneakAudio());
	}
	public IEnumerator CheckGunAudio(){
        Collider[] GunCols = Physics.OverlapSphere(transform.position, 20f);
		int i = 0;
		while(i < GunCols.Length){
			if(GunCols[i].GetComponent<PathFind>()){
				if(GunAudio.isPlaying && !GunAudio.GetComponent<Gun>().Silenced){
                    Debug.Log("LOUD");
					GunCols[i].GetComponent<PathFind>().TargetPlayer();
				}
			}
			i++;
		}
		yield return new WaitForSeconds(.5f);
		StartCoroutine(CheckGunAudio());
	}
    public IEnumerator CheckSilencedGunAudio()
    {
        Collider[] SilencedGunCols = Physics.OverlapSphere(transform.position, 10f);
        int i = 0;
        while (i < SilencedGunCols.Length)
        {
            if (SilencedGunCols[i].GetComponent<PathFind>())
            {
                if (GunAudio.isPlaying && GunAudio.GetComponent<Gun>().Silenced)
                {
                    Debug.Log("Silenced");
                    SilencedGunCols[i].GetComponent<PathFind>().TargetPlayer();
                }
            }
            i++;
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(CheckSilencedGunAudio());
    }
}
