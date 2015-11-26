using UnityEngine;
using System.Collections;

public class HackDoor : MonoBehaviour {
	public bool isOpen = false;
	public void Open(){
		transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
		isOpen = true;
	}
	public void Close(){
		transform.position = new Vector3(transform.position.x, .2f, transform.position.z);
		isOpen = false;
	}
}
