using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
	void Start () {
		transform.GetChild(1).GetComponent<Button>().onClick.AddListener(End);
		transform.GetChild(2).GetComponent<Button>().onClick.AddListener(Stats);
		transform.GetChild(3).gameObject.SetActive(false);
	}
	public void End(){
		Application.Quit();
	}
	public void Stats(){
        int LastHealth = (int)(Settings.Stats.HealthAmount * 100f);
        int MaxHealth = (int)(Settings.Stats.MaxHealth * 100f);
		transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Ammo Used: " + Settings.Stats.GunAmmoUsed.ToString() + "/" + Settings.Stats.TaserAmmoUsed.ToString() + "/" + Settings.Stats.SecCardAmmoUsed.ToString();
		transform.GetChild(3).GetChild(1).GetComponent<Text>().text = "Health: " + LastHealth.ToString() + "/" + MaxHealth.ToString();
        transform.GetChild(3).GetChild(2).GetComponent<Text>().text = "Killed: " + Settings.Stats.Killed.ToString();
        transform.GetChild(3).GetChild(3).GetComponent<Text>().text = "Pickups: " + Settings.Stats.PickupsUsed.ToString();
        transform.GetChild(3).GetChild(4).GetComponent<Text>().text = "Time: " + Settings.Stats.Time.ToString();
	}
}
