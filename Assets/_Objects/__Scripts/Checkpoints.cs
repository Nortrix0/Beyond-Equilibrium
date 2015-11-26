using UnityEngine;
using UnityEditor;
using System.Collections;

public class Checkpoints : MonoBehaviour {

    bool HasTriggered = false;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player" && !HasTriggered && !Settings.Checkpoint.Checkpoint){
            Debug.Log("CHECKPOINT");
            Settings.Checkpoint.HealthAmount = Settings.Stats.HealthAmount;
            Settings.Checkpoint.MaxHealth = Settings.Stats.MaxHealth;
            Settings.Checkpoint.GasAmount = Settings.Stats.GasAmount;
            Settings.Checkpoint.FlashlightAmount = Settings.Stats.FlashlightAmount;
            Settings.Checkpoint.GunAmmo = Settings.Stats.GunAmmo;
            Settings.Checkpoint.TazerAmmo = Settings.Stats.TazerAmmo;
            Settings.Checkpoint.SecCardAmmo = Settings.Stats.SecCardAmmo;
            Settings.Checkpoint.GunAmmoUsed = Settings.Stats.GunAmmoUsed;
            Settings.Checkpoint.TaserAmmoUsed = Settings.Stats.TaserAmmoUsed;
            Settings.Checkpoint.SecCardAmmoUsed = Settings.Stats.SecCardAmmoUsed;
            Settings.Checkpoint.PickupsUsed = Settings.Stats.PickupsUsed;
            Settings.Checkpoint.Killed = Settings.Stats.Killed;
            Settings.Checkpoint.Time = Settings.Stats.Time;
            Settings.Checkpoint.Position = col.transform.position;
            Settings.Checkpoint.Rotation = col.transform.rotation;
            Settings.Checkpoint.Checkpoint = true;
            Settings.Checkpoint.KilledInfo = Settings.Stats.KilledInfo;
            HasTriggered = true;
            GameObject.Find("Gassers").GetComponent<EnemyManager>().Save();
        }
        else if(Settings.Checkpoint.Checkpoint){
            Settings.Checkpoint.Checkpoint = false;
        }
    }
    public static void Load()
    {
        Debug.Log("LOAD");
        Settings.Stats.HealthAmount = Settings.Checkpoint.HealthAmount;
        Settings.Stats.MaxHealth = Settings.Checkpoint.MaxHealth;
        Settings.Stats.GasAmount = Settings.Checkpoint.GasAmount;
        Settings.Stats.FlashlightAmount = Settings.Checkpoint.FlashlightAmount;
        Settings.Stats.GunAmmo = Settings.Checkpoint.GunAmmo;
        Settings.Stats.TazerAmmo = Settings.Checkpoint.TazerAmmo;
        Settings.Stats.SecCardAmmo = Settings.Checkpoint.SecCardAmmo;
        Settings.Stats.GunAmmoUsed = Settings.Checkpoint.GunAmmoUsed;
        Settings.Stats.TaserAmmoUsed = Settings.Checkpoint.TaserAmmoUsed;
        Settings.Stats.SecCardAmmoUsed = Settings.Checkpoint.SecCardAmmoUsed;
        Settings.Stats.PickupsUsed = Settings.Checkpoint.PickupsUsed;
        Settings.Stats.Killed = Settings.Checkpoint.Killed;
        Settings.Stats.Time = Settings.Checkpoint.Time;
        Settings.Stats.Position = Settings.Checkpoint.Position;
        Settings.Stats.Rotation = Settings.Checkpoint.Rotation;
        Settings.Stats.Checkpoint = true;
        Settings.Stats.KilledInfo = Settings.Checkpoint.KilledInfo;
    }
}
