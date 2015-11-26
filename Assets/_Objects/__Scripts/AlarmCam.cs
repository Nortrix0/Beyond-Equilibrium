using UnityEngine;
using System.Collections;

public class AlarmCam : MonoBehaviour {
	public GameObject Player;
	public Camera Camera;
	public Camera MainCamera;
	public bool IsFriendly;
	public bool InUse;
	public KeyCode UseKey;
	public string hitString;
	RaycastHit hit;
	PathFind[] Pathfinds;
	//	Text DetectionTextTest;
	bool SameTick;
	
	void Start () {
		Pathfinds = GameObject.FindObjectsOfType(typeof(PathFind)) as PathFind[];
		Player = GameObject.FindGameObjectWithTag("Player");
		Camera = transform.GetChild(0).GetChild(0).GetComponent<Camera>();
		MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		//	DetectionTextTest = GameObject.Find("Text").GetComponent<Text>();
		Camera.enabled = false;
	}
	
	void FixedUpdate () {
		Vector3 RayHeading = Player.transform.position - Camera.gameObject.transform.position;
		float RayDis = RayHeading.magnitude;
		Vector3 RayDir = RayHeading/RayDis;
		if(Physics.Raycast(Camera.transform.position, RayDir, out hit, 10f)){
			Debug.DrawRay(Camera.transform.position, RayDir);
				hitString = hit.collider.name;
			if(hit.collider.gameObject == Player && !IsFriendly){
					Alert();
				//				DetectionTextTest.text = "DETECTED";
			}
			else{
				//				DetectionTextTest.text = "NOT DETECTED";
			}
		}
		if(InUse && !SameTick && Input.GetKeyDown(UseKey)){
			MainCamera.enabled = true;
			Camera.enabled = false;
			InUse = false;
			//Debug.Log("Not InUse");
			SameTick = true;
		}
		if(IsFriendly && !SameTick && Input.GetKeyDown(UseKey)){
			MainCamera.enabled = false;
			Camera.enabled = true;
			InUse = true;
			//Debug.Log("InUse");
			SameTick = true;
		}
		SameTick = false;
	}
	public void Alert(){
		foreach(PathFind path in Pathfinds){
			if(path.isActiveAndEnabled){
				path.agent.destination = hit.collider.gameObject.transform.position;
			}
		}
		//	Time.timeScale = 0;
	}
}
