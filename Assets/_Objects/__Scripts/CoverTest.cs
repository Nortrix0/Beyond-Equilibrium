using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider))]
public class CoverTest : MonoBehaviour {
	public bool FullCover = true;
	bool InCover = false;
	bool Exited = false;
	BoxCollider Bc;
	PlayerController Player;
    PlayerStats PS;
	void Start(){
        Player = PlayerStats.Player.GetComponent<PlayerController>();
		Bc = GetComponent<BoxCollider>();
        PS = Player.GetComponent<PlayerStats>();
	}
	void Update(){
		if(InCover){
			Player.Bounded(Bc.bounds);
		}
	}
    void OnTriggerEnter(Collider col)
    {
        if (Player.GetComponent<PlayerStats>().isSneaking)
        {
            InCover = true;
        }
    }
	void OnTriggerStay(Collider col){
        if (!PS.isSneaking)
        {
            UnCovered();
        }
		if(Input.GetKeyDown(Settings.CS.Keys[0].Key) || InCover){
			if(!FullCover){
                PlayerStats.Player.GetComponent<CharacterController>().height = 1f;
			}
			Covered();
		}
        if (!InCover)
        {
            UnCovered();
		}
	}
	void OnTriggerExit(){
        UnCovered();
        HUDManager.InteractText.text = "";
	}
	void Covered(){
        if(PS.isSneaking){
            HUDManager.InteractText.text = "Press " + Settings.CS.Keys[0].Key + " To Exit Cover";
        }
        if (Input.GetKeyDown(Settings.CS.Keys[0].Key) && InCover)
        {
			Exited = true;
			UnCovered();
		}
		if(!Exited){
			InCover = true;
		}
		Exited = false;
	}
	void UnCovered(){
        PlayerStats.Player.GetComponent<CharacterController>().height = 1.8f;
		InCover = false;
        if(!PS.isSneaking){
            HUDManager.InteractText.text = "Press " + Settings.CS.Keys[0].Key + " To Enter Cover";
        }
        else
        {
            Covered();
        }
	}
}
