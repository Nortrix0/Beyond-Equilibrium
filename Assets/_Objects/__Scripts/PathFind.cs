using UnityEngine;
using System.Collections;

public class PathFind : MonoBehaviour {
    GameSettings GameSettings;
	public NavMeshAgent agent;
	public float origSpeed;
	public float angle;
	public float Damage;
	public bool Tased = false;
	public bool FoundPlayer = false;
	public Vector3 StartPos;
	public Vector3 WanderPos;
	public float WanderSpeed;
	public float WanderRange;
	public bool Wandering;
	public NavMeshHit WanderingHit;
	public float NavDisRemaining;
    public bool OVRDest = false;

    void Start()
    {
        GameSettings = Settings.GS;
		StartPos = transform.position;
		agent = GetComponent<NavMeshAgent>();
		origSpeed = agent.speed;
		GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume * (GameSettings.SFXVol/100);
        if (GameSettings.Difficulty == 0) Damage = .01f;
		if (GameSettings.Difficulty == 1) Damage = .02f;
        if (GameSettings.Difficulty == 2) Damage = .05f;
        if (GameSettings.Difficulty == 3) Damage = .1f;
		InvokeRepeating("Wander", .5f, 3f);
	}

	void Update () {
		if(FoundPlayer){
			Wandering = false;
			if(!Tased && gameObject.activeInHierarchy){
				agent.speed = origSpeed;
				NavDisRemaining = agent.remainingDistance;
				if(NavDisRemaining < 1.5f && transform.GetChild(4).GetComponent<Lookat>().SeePlayer){
					Wandering = true;
					agent.speed = WanderSpeed;
				}
			}
		}
		else{
			Wandering = true;
		}
	}
	public void TargetPlayer(){
		FoundPlayer = true;
		agent.destination = PlayerStats.Player.transform.position;
	}
	public IEnumerator Stop(){
		Tased = true;
		GetComponent<EnemyHealth>().CurrHealth -= 1;
        agent.destination = PlayerStats.Player.transform.position;
		agent.speed = 0f;
		yield return new WaitForSeconds(1f);
		agent.speed = origSpeed;
		Tased = false;
	}

	void OnTriggerStay(Collider col){
		if(col.CompareTag("Player")/* && agent.destination == col.transform.position*/){
            Settings.Stats.HealthAmount -= .02f;
            Settings.Stats.GasAmount -= .003f;
		}
	}
	void Wander(){
		if(Wandering && gameObject != null && !OVRDest){
			agent.speed = WanderSpeed;
			WanderPos = transform.position + Random.insideUnitSphere * WanderRange;
			if(NavMesh.SamplePosition(WanderPos, out WanderingHit, 1f, NavMesh.AllAreas) && gameObject != null){
				agent.destination = WanderingHit.position;
			}
			else{
				Wander();
			}
		//	agent.destination = WanderPos;
		}
	}
    public void Kill()
    {
        agent.Stop();
        gameObject.SetActive(false);
    }
}
