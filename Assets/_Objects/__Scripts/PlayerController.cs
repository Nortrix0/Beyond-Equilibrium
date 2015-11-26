using UnityEngine;
using System;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    public GameSettings GameSettings;
	CharacterController cc;
	Camera MainCamera;
	public float MovementSpeed = 5f;
	public float MouseSpeed = 2f;
	public float MouseVertRange = 60f;
	public float MaxSlope = 75f;
	public Vector3 Dir;
	public bool InvertX;
	public bool InvertY;
	float VertRot = 0;
	Vector3 PlayerPos;
	bool Restricted = false;

    void Start()
    {
        GameSettings = Settings.GS;
		cc = GetComponent<CharacterController>();
		MainCamera = Camera.main;
		cc.slopeLimit = MaxSlope;
	}
    void Update()
    {
        if(Time.timeScale == 1){
            Move();
        }
    }

	void Move () {
		InvertX = GameSettings.InvertX;
		InvertY = GameSettings.InvertY;
		float MouseX = Input.GetAxis("Mouse X") * MouseSpeed;
		float MouseY = Input.GetAxis("Mouse Y") * MouseSpeed;
		if(!InvertX){transform.Rotate(0, MouseX, 0);}
		else{transform.Rotate(0, -MouseX, 0);}
		if(!InvertY){VertRot -= MouseY;}
		else{VertRot += MouseY;}
		VertRot = Mathf.Clamp(VertRot, -MouseVertRange, MouseVertRange);
		MainCamera.transform.localRotation = Quaternion.Euler(VertRot,0,0);

		float ForwardSpeed = Input.GetAxis("Vertical") * MovementSpeed;
		float SidewaysSpeed = Input.GetAxis("Horizontal") * MovementSpeed;
		Dir = new Vector3(SidewaysSpeed, 0, ForwardSpeed);
		Dir = transform.rotation * Dir;
		if(!Restricted){
			cc.SimpleMove(Dir);
		}
	}
	public void Bounded(Bounds b){
		Restricted = true;
		PlayerPos = transform.localPosition;
		PlayerPos.x = Mathf.Clamp(PlayerPos.x,b.min.x, b.max.x);
		PlayerPos.z = Mathf.Clamp(PlayerPos.z,b.min.z, b.max.z);
		transform.localPosition = PlayerPos;
		cc.SimpleMove(Dir);
		Restricted = false;
	}
}
