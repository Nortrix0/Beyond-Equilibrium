using UnityEngine;
using System.Collections;

public class Knife : MonoBehaviour {
	public KeyCode KnifeKey;
    void Update()
    {
        KnifeKey = Settings.CS.Keys[5].Key;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.forward, out hit) && Input.GetKeyDown(KnifeKey)){
            if(hit.collider.GetComponent<EnemyHealth>()){
                if(!hit.collider.GetComponent<PathFind>().FoundPlayer){
                    hit.collider.GetComponent<EnemyHealth>().CurrHealth -= 117;
                }
                hit.collider.GetComponent<EnemyHealth>().CurrHealth -= 2;
            }
        }
    }
}
