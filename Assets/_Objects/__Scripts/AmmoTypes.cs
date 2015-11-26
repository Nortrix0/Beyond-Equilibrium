using UnityEngine;
using System.Collections;

public class AmmoTypes : MonoBehaviour {

    public Ammo[] AmmoType;
    public void RandomAmmo(GameObject Go)
    {
        Ammo TempAmmo = AmmoType[Random.Range(0, AmmoType.Length - 1)];
        GameObject ammo = Instantiate(TempAmmo.Model);
        Go.GetComponent<AmmoBox>().AmmoType = TempAmmo.Name;
        ammo.transform.SetParent(Go.transform);
        ammo.transform.position = Go.transform.position;
        ammo.GetComponent<MeshCollider>().convex = true;
        ammo.AddComponent<Rigidbody>();
    }
    public static void GetAmmo(string AmmoString, GameObject Go)
    {
        HUDManager.InteractText.text = "";
        Settings.Stats.PickupsUsed += 1;
        if (AmmoString == "Bullet" && Settings.Stats.GunAmmo < 9)
        {
            Settings.Stats.GunAmmo += 1;
            Destroy(Go);
        }
        else if (AmmoString == "Powercell" && Settings.Stats.TazerAmmo < 9)
        {
            Settings.Stats.TazerAmmo += 1;
            Destroy(Go);
        }
        else if (AmmoString == "Healthpack" && Settings.Stats.HealthAmount < Settings.Stats.MaxHealth)
        {
            if (Settings.Stats.HealthAmount + 1 <= Settings.Stats.MaxHealth)
            {
                Settings.Stats.HealthAmount = 1;
            }
            else
            {
                Settings.Stats.HealthAmount = Settings.Stats.MaxHealth;
            }
            Destroy(Go);
        }
        else if (AmmoString == "Duct Tape" && Settings.Stats.GasAmount < 1)
        {
            Settings.Stats.GasAmount = 1;
            Destroy(Go);
        }
        else if (AmmoString == "Battery (D)" && Settings.Stats.FlashlightAmount < 1)
        {
            Settings.Stats.FlashlightAmount = 1;
            Destroy(Go);
        }
        else if (AmmoString == "Battery (AA)" && Settings.Stats.SecCardAmmo < 5)
        {
            Settings.Stats.SecCardAmmo += 1;
            Destroy(Go);
        }
    }
}
[System.Serializable]
public class Ammo
{
    public string Name;
    public GameObject Model;
}
