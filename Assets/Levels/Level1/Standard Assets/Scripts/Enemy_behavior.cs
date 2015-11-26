using UnityEngine;
using System.Collections;

public class Enemy_behavior : MonoBehaviour 
{

	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public Transform fpsTarget;
	Rigidbody theRigidBody;
	Renderer myRender;






	// Use this for initialization
	void Start () {
		myRender = GetComponent<Renderer> ();
		theRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		fpsTargetDistance = Vector3.Distance (fpsTarget.position, transform.position);
		if( fpsTargetDistance<enemyLookDistance)
		{
			myRender.material.color = Color.yellow;
			lookAtPlayer();
			print("Look at player please!");
		}
			if (fpsTargetDistance < attackDistance) 
			{
				attackPlease();
				print("Attack");
			}
	
	}

	void lookAtPlayer()
		{
		Quaternion rotation = Quaternion.LookRotation (fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
		}
	void attackPlease()
		{
			theRigidBody.AddForce(transform.forward*enemyMovementSpeed);
		}
	}


