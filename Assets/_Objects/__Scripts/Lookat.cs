using UnityEngine;
using System.Collections;

public class Lookat : MonoBehaviour {
	public GameObject Player;
	public int FOV;
	public float angle;
	public bool SeePlayer;
	public string HitText;

	void Update () {
		if(Player != null){
			Vector3 Dir = Player.transform.position - transform.position;
			angle = Vector3.Angle(Dir, transform.forward);
			if(angle < FOV * .5f){
				RaycastHit hit;
				if(Physics.Raycast(transform.position, Dir.normalized, out hit) && gameObject.activeInHierarchy){
					HitText = hit.collider.ToString();
					if(hit.collider.CompareTag("Player")){
						SeePlayer = true;
						GetComponentInParent<PathFind>().TargetPlayer();
					}
					else{
						SeePlayer = false;
					}
				}
			}
			else{
				SeePlayer = false;
			}
		}
		if(Player == null){
            Player = PlayerStats.Player;
		}
	}
}
