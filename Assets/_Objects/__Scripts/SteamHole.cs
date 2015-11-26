using UnityEngine;
using System.Collections;
[RequireComponent(typeof (ParticleSystem))]
[RequireComponent(typeof(AudioSource))]
public class SteamHole : MonoBehaviour {
    ParticleSystem PS;
    float Value;
    AudioSource AS;
    public float DisapateRate = .1f;
    public float StopAmount = 0.125f;
    public float ParticleOffset = .1f;
    public GameObject HitObject;
	void Start () {
        transform.LookAt(PlayerStats.Player.transform.position);
        PS = GetComponent<ParticleSystem>();
        AS = GetComponent<AudioSource>();
        Value = HitObject.GetComponent<SteamAmount>().Amount;
        PS.Play();
        StartCoroutine(CheckSteamAudio());
	}
	
	void Update () {
        Value -= (Value - DisapateRate) * Time.deltaTime;
        HitObject.GetComponent<SteamAmount>().Amount = Value;
        if(Value <= StopAmount){
            PS.Stop();
            Destroy(gameObject);
        }
	}
    public IEnumerator CheckSteamAudio()
    {
        Collider[] SteamCols = Physics.OverlapSphere(transform.position, 20f);
        int i = 0;
        while (i < SteamCols.Length)
        {
            if (SteamCols[i].GetComponent<PathFind>())
            {
                PathFind P = SteamCols[i].GetComponent<PathFind>();
                if (AS.isPlaying)
                {
                    P.OVRDest = true;
                    P.agent.destination = this.transform.position;
                    
                }
                else
                {
                    P.OVRDest = false;
                }
            }
            i++;
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(CheckSteamAudio());
    }
}
