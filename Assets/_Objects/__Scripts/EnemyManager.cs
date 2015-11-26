using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {
	void Start () {
        if(Settings.Stats.KilledInfo.Count == 0){
            Debug.Log("Creating");
            for (int i = 0; i < transform.childCount; i++ )
            {
                Settings.Stats.KilledInfo.Add(new EnemyInfo { T = transform.GetChild(i).position, EH = transform.GetChild(0).GetComponent<EnemyHealth>().CurrHealth });
            }
        }
        else
        {
            Debug.Log("Using");
            for (int i = 0; i < transform.childCount; i++ )
            {
                transform.GetChild(i).position = Settings.Stats.KilledInfo[i].T;
                transform.GetChild(i).GetComponent<EnemyHealth>().CurrHealth = Settings.Stats.KilledInfo[i].EH;
                if (Settings.Stats.KilledInfo[i].EH <= 0)
                {
                    Settings.Stats.Killed--;
                }
            }
        }
	}
    public void Save()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Settings.Stats.KilledInfo[i].T = transform.GetChild(i).position;
            Settings.Stats.KilledInfo[i].EH = transform.GetChild(i).GetComponent<EnemyHealth>().CurrHealth;
            if (Settings.Stats.KilledInfo[i].EH <= 0)
            {
                Settings.Stats.Killed--;
            }
        }
    }
}
[System.Serializable]
public class EnemyInfo
{
    public Vector3 T;
    public int EH;
}
