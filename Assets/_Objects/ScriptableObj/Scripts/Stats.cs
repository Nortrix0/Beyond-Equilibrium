using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stats : ScriptableObject {
    [Range(0, 1)]
    public float HealthAmount;
    public float MaxHealth;
    [Range(0, 1)]
    public float GasAmount;
    [Range(0, 1)]
    public float FlashlightAmount;
    [Range(0, 9)]
    public int GunAmmo;
    [Range(0, 9)]
    public int TazerAmmo;
    [Range(0, 5)]
    public int SecCardAmmo;
    public int GunAmmoUsed;
    public int TaserAmmoUsed;
    public int SecCardAmmoUsed;
    public int PickupsUsed;
    public int Killed;
    public float Time;
    public bool Silenced;
    public Vector3 Position;
    public Quaternion Rotation;
    public bool Checkpoint;
    public List<EnemyInfo> KilledInfo;
    public void Reset(){
        HealthAmount = 1;
        MaxHealth = 1;
        GasAmount = 1;
        FlashlightAmount = 1;
        GunAmmo = 9;
        TazerAmmo = 9;
        SecCardAmmo = 5;
        GunAmmoUsed = 0;
        TaserAmmoUsed = 0;
        SecCardAmmoUsed = 0;
        PickupsUsed = 0;
        Killed = 0;
        Time = 0;
        Silenced = false;
        Position = Vector3.zero;
        Rotation = Quaternion.identity;
        Checkpoint = false;
        KilledInfo.Clear();
    }
}
