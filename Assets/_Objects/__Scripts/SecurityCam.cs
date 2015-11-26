using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecurityCam : MonoBehaviour {
	public GameObject Player;
	public Camera Camera;
	public Camera MainCamera;
	public bool IsFriendly;
	public bool InUse;
	public string hitString;

	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		Camera = transform.GetChild(0).GetChild(0).GetComponent<Camera>();
		MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		Camera.enabled = false;
	}

	void FixedUpdate () {
		if(InUse && Input.GetKey(KeyCode.Escape)){
			MainCamera.enabled = true;
			Camera.enabled = false;
			InUse = false;
			IsFriendly = false;
		}
		if(IsFriendly){
			MainCamera.enabled = false;
			Camera.enabled = true;
			InUse = true;
		}
	}
	public void Alert(){
	}
}
